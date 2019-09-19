using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; // Global variable to keep track of whether or not game is paused
    public GameObject pauseMenuUI; // The game object containing the pause menu items

    private FoxMovement foxMovement; // Script reference
    private FollowManager followManager; // Script reference

    // Find script references
    private void Start()
    {
        foxMovement = FindObjectOfType<FoxMovement>();
        followManager = FindObjectOfType<FollowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses escape button
        if (Input.GetButtonDown("Escape"))
        {
            // Check if isPaused is true, if so, resume the game
            if (isPaused == true)
            {
                Resume();
            }
            // Otherwise, pause the game
            else
            {
                Pause();
            }
        }
    }

    // Called when the if else statment is true
    void Resume()
    {
        // Hide pause menu UI
        pauseMenuUI.SetActive(false);
        // Change timeScale back to 1
        Time.timeScale = 1f;
        // set isPaused to false
        isPaused = false;
        // Reenable fox movement
        foxMovement.isControlling = true;
    }

    // Called when the if else statment is false
    void Pause()
    {
        // Show pause menu UI
        pauseMenuUI.SetActive(true);
        // Change timeScale to 0
        Time.timeScale = 0f;
        // set isPaused to true
        isPaused = true;
        // Disable fox movement
        foxMovement.isControlling = false;
    }

    // Triggered when the retry button in the pause menu is pressed
    public void Retry()
    {
        // Unpause game
        isPaused = false;
        // Reset timeScale
        Time.timeScale = 1f;
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Triggered when the menu button is pressed
    public void LoadMenu()
    {
        // Reset timescale
        Time.timeScale = 1f;
        // Load main menu
        SceneManager.LoadScene("MainMenu");
    }

    // Triggered when the exit button is pressed
    public void QuitGame()
    {
        Debug.Log("GAME QUIT!");
        Application.Quit();
    }
}