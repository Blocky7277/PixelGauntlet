using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    [SerializeField]
    private BossManager bossManager;

    [SerializeField]
    private Canvas attackScreen;

    [SerializeField]
    private GameManager gameManager;

    public void DoAttack(){
        bossManager.takeDamage(gameManager.GetPlayerController().str+1000);
        attackScreen.gameObject.SetActive(false);
    }
}
