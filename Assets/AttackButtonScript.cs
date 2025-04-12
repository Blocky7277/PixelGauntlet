using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    [SerializeField]
    private BossManager bossManager;

    [SerializeField]
    private Canvas minigameScreen;

    [SerializeField]
    private GameManager gameManager;

    public void DoAttack(){
        minigameScreen.gameObject.SetActive(true);
    }
}
