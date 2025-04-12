using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    [SerializeField]
    private BossManager bossManager;
    [SerializeField]
    private Canvas attackScreen;
    public void doAttack(){
        bossManager.takeDamage(5);
        attackScreen.gameObject.SetActive(false);
    }
}
