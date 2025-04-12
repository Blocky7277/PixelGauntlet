using System;
using System.Collections;
using System.Linq;
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
    private Canvas defeatScreen;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject shieldPrefab;

    private Assist[] assists = new Assist[3];
    private KeyCode[] assistKeyCodes = {KeyCode.J, KeyCode.K, KeyCode.L};
    [SerializeField]
    private GameObject[] assistCooldownVisual = new GameObject[3];

    public Sprite skeleton;
    public Sprite stereo;
    [SerializeField]
    private GameObject bossIcon;

    void Start()
    {
        assists[0] = new Assist(12f, 0f, false, AssistTypes.SHIELD);       
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
            if(Input.GetKeyDown(assistKeyCodes[i]) && !assists[i].active && assists[i].cooldownComplete) {
                playerController.activeAssists[i] = assists[i];
                assists[i].cooldownComplete = false;
                useAssist(assists[i]);
                StartCoroutine(AssistCooldown(assists[i]));
                if(assists[i].duration > 0) {
                    StartCoroutine(AssistDuration(assists[i]));
                }
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
        bossManager.totalTime = -2f;
        bossManager.destroyAttacks();
        
        if (bossManager.currentBoss == "skeleton"){
            bossManager.currentBoss = "stereo";
            bossIcon.GetComponent<SpriteRenderer>().sprite = stereo;
        }
        else{
            bossManager.currentBoss = "skeleton";
            bossIcon.GetComponent<SpriteRenderer>().sprite = skeleton;
        }
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
        if(assists[2] == null) {
            assists.Append(assist);
        }
        else {
            assists[0] = assist;
        }
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

    IEnumerator AssistCooldown(Assist assist) {
        float elapsed = 0f;
        while(elapsed < assist.cooldown) {
            if (!attackScreen.gameObject.activeSelf && !defeatScreen.gameObject.activeSelf) elapsed += Time.deltaTime;
            yield return null;
        }
        assist.cooldownComplete = true;
    }

    IEnumerator AssistDuration(Assist assist) {
        float elapsed = 0f;
        while(elapsed < assist.duration) {
            if (!attackScreen.gameObject.activeSelf && !defeatScreen.gameObject.activeSelf) elapsed += Time.deltaTime;
            yield return null;
        }
        deactivateAssist(assist);
    }
}
