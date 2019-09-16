using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    // Method to load the next scene when play button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method not yet implemented
    public void HowToPlay() {
        
    }

    // Method not yet implemented
    public void LevelSelect() {
        
    }

    // Quits the game when the exit button is pressed
    public void QuitGame()
    {
        Debug.Log("GAME QUIT!");
        Application.Quit();
    }
}
