using System;
using Unity.Mathematics;
using UnityEngine;

public class AssistButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    public Canvas defeatCanvas; 

    public void OnClick() {
        System.Random rnd = new System.Random();
        Debug.Log(rnd.Next(0,2));
        if(rnd.Next(0,2) == 0) {
            gameManager.AddAssist(new Assist(12f, 0f, false, AssistTypes.SHIELD));
        }
        else {
           gameManager.AddAssist(new Assist(5f, .5f, false, AssistTypes.DASH)); 
        }
        gameManager.resetBoss();
        defeatCanvas.gameObject.SetActive(false);
    }
}