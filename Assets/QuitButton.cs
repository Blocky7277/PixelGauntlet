using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public GameManager gameManager;

    public void OnClick() {
        SceneManager.LoadScene("Title Screen");
    }
}
