using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CharacterController character;
    public CharacterController character2;
    public Timer timer;

    public void ResumeGame() {
        Debug.Log("Unpause");
        character.setPause(false);
        character2.setPause(false);
        timer.resume();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void MainMenuScene() {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
