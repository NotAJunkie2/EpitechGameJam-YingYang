using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void MainMenuScene() {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
