using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int health {get; set;} = 100;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Canvas attackScreen;
    
    [SerializeField]
    private Canvas defeatScreen;
    
    [SerializeField]
    private GameObject circleAttack;

    public GameObject healthbar;

    private float totalTime = 0f;
    
    public void takeDamage(int damageToDeal){
        float percentHealthDealt = ((float)damageToDeal)/health;
        health -= damageToDeal;
        healthbar.transform.position -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x/2, 0, 0);
        healthbar.transform.localScale -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x, 0, 0);
        if (health <= 0){
            player.SetActive(false);
            defeatScreen.gameObject.SetActive(true);
        }
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