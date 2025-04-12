using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void goToPlayScene() {
        SceneManager.LoadScene("Skeleton Boss Scene");
    }
}
