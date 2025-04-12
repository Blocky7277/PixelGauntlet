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

    [SerializeField]
    private GameObject horizBeamAttack;

    [SerializeField]
    private GameObject vertBeamAttack;

    public GameObject healthbar;

    public float totalTime = -2f;

    public string currentBoss {get; set;} = "skeleton";

    private List<GameObject> generatedObjects = new List<GameObject>();
    
    public void takeDamage(int damageToDeal){
        float percentHealthDealt = ((float)damageToDeal)/health;
        health -= damageToDeal;
        totalTime = -1f;
        Debug.Log(health);
        healthbar.transform.position -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x/2, 0, 0);
        healthbar.transform.localScale -= new Vector3(percentHealthDealt*healthbar.transform.localScale.x, 0, 0);
        if (health <= 0){
            player.SetActive(false);
            defeatScreen.gameObject.SetActive(true);
        }
        destroyAttacks();
    }

    public void destroyAttacks(){
        foreach(var obj in generatedObjects)
        {
            Destroy(obj);
        }
    }

    private void spawnCircleAttack(){
        var circle = Instantiate(circleAttack, new Vector3(Random.Range(-5.43f, 5.43f),Random.Range(-3.5f, 0f),-1), new Quaternion(0,0,0,0));
        generatedObjects.Add(circle);
    }

    private void spawnBeamAttack(){
        if (Random.Range(0, 2) == 0){
            var beam = Instantiate(vertBeamAttack, new Vector3(Random.Range(-6f, 6f),-1.75f,-1), new Quaternion(0,0,90,90));
            generatedObjects.Add(beam);
        }
        else{
            var beam = Instantiate(horizBeamAttack, new Vector3(0,Random.Range(-4f, 0.5f),-1), new Quaternion(0,0,0,0));
            generatedObjects.Add(beam);
        }
    }

    void Update(){
        totalTime += Time.deltaTime;
        if (currentBoss == "skeleton"){
            if (!attackScreen.gameObject.activeSelf && totalTime >= 0.5f){
                spawnCircleAttack();
                totalTime = 0f;
            }
        }
        else{
            if (!attackScreen.gameObject.activeSelf && totalTime >= 0.75f){
                spawnBeamAttack();
                totalTime = 0f;
            }
        }
    }
}