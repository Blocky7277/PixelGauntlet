using UnityEngine;

public class ShieldAssist : MonoBehaviour {
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 20f * Time.deltaTime));
    }
}