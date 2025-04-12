using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbScript : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private Canvas defeatCanvas;

    public void gainStats(){
        playerController.str += Random.Range(2, 5);
        if (Random.Range(0, 2) == 1){
            playerController.health += 1;
        }
        playerController.spd += Random.Range(2, 5);
        this.gameObject.SetActive(false);
        defeatCanvas.gameObject.SetActive(false);
    }
}
