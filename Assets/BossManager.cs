using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private Canvas attackScreen;
    
    [SerializeField]
    private GameObject circleAttack;

    private float totalTime = 0f;
    
    public void takeDamage(int damageToDeal){
        health -= damageToDeal;
        Debug.Log(health);
    }

    private void spawnCircleAttack(){
        Instantiate(circleAttack, new Vector3(0,0,-1), new Quaternion(0,0,0,0));
    }

    void Update(){
        totalTime += Time.deltaTime;
        if (!attackScreen.gameObject.activeSelf && totalTime >= 2f){
            spawnCircleAttack();
            totalTime = 0f;
        }
    }
}
