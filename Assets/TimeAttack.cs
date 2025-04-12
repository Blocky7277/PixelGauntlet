using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [SerializeField]
    private BossManager bossManager;

    [SerializeField]
    private Canvas attackScreen;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject bar;

    private bool barGoingLeft = false;
    
    public void attack(){
        bossManager.takeDamage(gameManager.GetPlayerController().str * (int)(Mathf.Abs(bar.transform.position.x/4.75f)));
        attackScreen.gameObject.SetActive(false);
    }

    void Update(){
        if (bar.transform.position.x <= -4.75){
            barGoingLeft = false;
        }
        else if (bar.transform.position.x >= 4.75){
            barGoingLeft = true;
        }

        if (barGoingLeft){
            bar.transform.position += new Vector3(-0.05f, 0, 0);
        }
        else if (!barGoingLeft){
            bar.transform.position += new Vector3(0.05f, 0, 0);
        }
    }
}
