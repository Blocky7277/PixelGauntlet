using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float totalTime = 0f;
    [SerializeField]
    private Canvas attackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 10f){
            attackScreen.gameObject.SetActive(true);
        }
    }
}
