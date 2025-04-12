using UnityEngine;

public class ShieldAssist : Assist {
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 20f * Time.deltaTime));
    }
}