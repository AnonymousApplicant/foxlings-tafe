using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject howToMenu;

    // Method to load the next scene when play button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Hides main menu and shows help menu
    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    // Shows main menu and hides help menu
    public void Back()
    {
        mainMenu.SetActive(true);
        howToMenu.SetActive(false);
    }

    // Method not yet implemented
    public void LevelSelect()
    {

    }

    // Quits the game when the exit button is pressed
    public void QuitGame()
    {
        Debug.Log("GAME QUIT!");
        Application.Quit();
    }
}
