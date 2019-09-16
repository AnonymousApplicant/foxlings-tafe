using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

/// <summary>
/// Manages the HUD
/// </summary>
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI captured; // Captured text for when you or your foxlings are captured (also used for time limit)
    public TextMeshProUGUI stars; // Text to display how many stars you got at the end
    public TextMeshProUGUI congrats; // Congratulations text when you complete a level
    public TextMeshProUGUI timerText; // Text that displays all three times
    public Button retry; // Retry button to retry levels
    public List<Image> foxlingCounter; // List of foxling icon images
    public float levelTime; // Float variable for the level time limit
    public float starTime; // Float variable for the level time star 

    private int listTracker; // Keeps track of the amount of foxlings in the following list
    private FollowManager followManager; // Variable that holds the followManager script
    private FoxMovement foxMovement; // Variable that holds the foxMovement script
    private float timer; // float variable that keeps track of the timer

    // Find the FollowManager and FoxMovement script and assign them
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
        foxMovement = FindObjectOfType<FoxMovement>();
    }

    // Set listTracker to the count of collectedFoxes
    private void Start()
    {
        listTracker = followManager.collectedFoxes.Count;
    }

    // Update and track timer, and foxling counter ui
    private void Update()
    {
        // If you can control character, increase timer, se timer texts using method, check if timer is more than the level time limit
        if (foxMovement.isControlling == true) 
        {
            timer += Time.deltaTime;

            timerText.SetText("Timer: " + TimeConvert(timer) + Environment.NewLine + "Star " + TimeConvert(starTime) + " / " + TimeConvert(levelTime) + " Limit");

            if (timer > levelTime)
            {
                captured.SetText("Times Up");
                Failed();
            }
        }

        // If current collectedFoxes.Count is not the same as listTracker then based on new count, deactivate the grey icon and activate the coloured icon
        if (followManager.collectedFoxes.Count != listTracker)
        {
            if (followManager.collectedFoxes.Count == 2)
            {
                foxlingCounter[0].gameObject.SetActive(false);
                foxlingCounter[3].gameObject.SetActive(true);
            }
            else if (followManager.collectedFoxes.Count == 3)
            {
                foxlingCounter[1].gameObject.SetActive(false);
                foxlingCounter[4].gameObject.SetActive(true);
            }
            else if (followManager.collectedFoxes.Count == 4)
            {
                foxlingCounter[2].gameObject.SetActive(false);
                foxlingCounter[5].gameObject.SetActive(true);
            }
        }
    }

    // Triggered when retry button is pressed
    public void RetryClicked()
    {
        // Reloads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Captured method that displays captured text
    public void Failed()
    {
        // Display UI
        captured.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);
        // Disable player movement
        foxMovement.isControlling = false;
    }

    // Trigger when the player steps into the finish trigger with all 3 pups
    public void FinishGame()
    {
        // Stop the followMovement
        PauseMenu.isPaused = true;

        // Display UI
        congrats.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        // Display correct amount of stars (only 2 or 3), without getting caught star not implemented
        if (timer < starTime)
        {
            stars.SetText("AAA");
        }
        else
        {
            stars.SetText("AA");
        }

        // Display stars
        stars.gameObject.SetActive(true);
        // Disable player movement
        foxMovement.isControlling = false;
    }

    // Converts floats into integers and display as time (90 = 01:30)
    private string TimeConvert(float time)
    {
        // Assign minutes and second variables 
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        // Format the result string
        string result = string.Format("{0:00}:{1:00}", minutes, seconds);
        // Return result
        return result;
    }
}
