using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void QuitGame() {
        Application.Quit();
    }

    public void MainMenuScene() {
        SceneManager.LoadScene("MainMenu");
    }
}
