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

    [SerializeField]
    private GameObject healthbar;

    private float totalTime = 0f;
    
    public void takeDamage(int damageToDeal){
        float percentHealthDealt = ((float)damageToDeal)/health;
        health -= damageToDeal;
        Debug.Log(health);
        healthbar.transform.position -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x/2, 0, 0);
        healthbar.transform.localScale -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x, 0, 0);
    }

    private void spawnCircleAttack(){
        Instantiate(circleAttack, new Vector3(Random.Range(-5.43f, 5.43f),Random.Range(-3.5f, 0f),-1), new Quaternion(0,0,0,0));
    }

    void Update(){
        totalTime += Time.deltaTime;
        if (!attackScreen.gameObject.activeSelf && totalTime >= 0.5f){
            spawnCircleAttack();
            totalTime = 0f;
        }
    }
}
