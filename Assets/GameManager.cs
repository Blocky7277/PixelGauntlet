using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float totalTime {get; set;} = 0f;
    [SerializeField]
    private Canvas attackScreen;

    [SerializeField]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
