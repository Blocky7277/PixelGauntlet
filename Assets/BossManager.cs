using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    
    public void takeDamage(int damageToDeal){
        health -= damageToDeal;
        Debug.Log(health);
    }
}
