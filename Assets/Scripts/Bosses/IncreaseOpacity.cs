using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseOpacity : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float opacitynum = 0f;
    public float attackspeed = 1f;
    public float disappearspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opacitynum >= 1f){
            spriteRenderer.color = new Color(1f, 1f, 1f, opacitynum);
            opacitynum += Time.deltaTime * disappearspeed;
            Destroy(this.gameObject, disappearspeed);
        }
        else{
            opacitynum += Time.deltaTime * attackspeed;
            spriteRenderer.color = new Color(1f, 0f, 0f, opacitynum);
        }
    }
}
