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
    public TextMeshProUGUI captured; // Captured text for when you or your foxlings are captured
    public TextMeshProUGUI stars;
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI timerText;
    public Button retry;
    public List<Image> foxlingCounter;
    public float levelTime;
    public float starTime;

    private int listTracker;
    private FollowManager followManager;
    private FoxMovement foxMovement;
    private float timer;

    // Find the FollowManager script and assign to followManager
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
        foxMovement = FindObjectOfType<FoxMovement>();
    }

    private void Start()
    {
        listTracker = followManager.collectedFoxes.Count;
    }

    private void Update()
    {
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

    public void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Captured method that displays captured text
    public void Failed()
    {
        captured.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        foxMovement.isControlling = false;
    }

    public void FinishGame()
    {
        congrats.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        if (timer < starTime)
        {
            stars.SetText("AAA");
        }
        else
        {
            stars.SetText("AA");
        }

        stars.gameObject.SetActive(true);
        foxMovement.isControlling = false;
    }

    private string TimeConvert(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        string result = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        return result;
    }
}
