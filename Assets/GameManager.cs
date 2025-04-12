using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum AssistTypes {
    SHIELD
}

public class GameManager : MonoBehaviour
{
    private float totalTime {get; set;} = 0f;
    [SerializeField]
    private Canvas attackScreen;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject shieldPrefab;

    private Assist[] assists = new Assist[3];
    private KeyCode[] assistKeyCodes = {KeyCode.J, KeyCode.K, KeyCode.L};

    void Start()
    {
        assists[0] = new Assist(1f, 1f, false, AssistTypes.SHIELD);       
    }

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BossManager bossManager;

    // Update is called once per frame
    void Update()
    {
        if (!attackScreen.gameObject.activeSelf){
            totalTime += Time.deltaTime;
        }
        if (totalTime >= 10f){
            attackScreen.gameObject.SetActive(true);
            totalTime = 0f;
        }

        for (int i = 0; i < assistKeyCodes.Length; i++)  {
            if(Input.GetKeyDown(assistKeyCodes[i]) && !assists[i].active) {
                playerController.activeAssists[i] = assists[i];
                useAssist(assists[i]);
            }
        }
    }

    public void resetBoss(){
        attackScreen.gameObject.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector3(0, -1.5f, 0);
        bossManager.health = 100;
        bossManager.healthbar.transform.position = new Vector3(0, 4.4f, -1f);
        bossManager.healthbar.transform.localScale = new Vector3(10f, 0.4f, 1f);
    }

    public void TransitionScene(UnityEngine.SceneManagement.Scene scene) {
        SceneManager.LoadScene(scene.name);
    }

    public void TransitionScene(UnityEngine.SceneManagement.Scene scene, float delay) {
        StartCoroutine(DelayedTransition(scene, delay));
    }

    IEnumerator DelayedTransition(UnityEngine.SceneManagement.Scene scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene.name);
    }

    public PlayerController GetPlayerController() {
        return playerController;
    }

    public void AddAssist(Assist assist) {
        assists.Append(assist);
    }

    public void useAssist(Assist assist) {
        assist.active = true;
        if (assist.assistType == AssistTypes.SHIELD) {
            assist.obj = Instantiate(shieldPrefab, playerController.gameObject.transform);
        }
    }

    public void deactivateAssist(Assist assist) {
        Destroy(assist.obj);
        assist.obj = null;
        assist.active = false;
    }

}
