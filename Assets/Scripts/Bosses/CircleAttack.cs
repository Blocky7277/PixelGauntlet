using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float opacitynum = 0f;

    [SerializeField]
    private float attackspeed = 1f;

    [SerializeField]
    private float disappearspeed = 1f;

    [SerializeField]
    private int dmg = 1;

    private bool didDamage = false;

    // Update is called once per frame
    void Update()
    {
        if (opacitynum >= 1f){
            spriteRenderer.color = new Color(1f, 1f, 1f, opacitynum);
            opacitynum += Time.deltaTime * disappearspeed;
            Destroy(gameObject, disappearspeed);
        }
        else{
            opacitynum += Time.deltaTime * attackspeed;
            spriteRenderer.color = new Color(1f, 0f, 0f, opacitynum);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(opacitynum >= 1 && collision.gameObject.CompareTag("Player") && !didDamage) {
            didDamage = true;
            collision.gameObject.GetComponent<PlayerController>().DealDamage(dmg);
            Destroy(gameObject);
        }        
    }
}
