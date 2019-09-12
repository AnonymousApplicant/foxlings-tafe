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
    public TextMeshProUGUI disclaimer;
    public TextMeshProUGUI instructions;
    public Image background;
    public Button retry;
    public Button start;
    public Image title;
    public List<Image> foxlingCounter;
    public int levelTime;

    private int listTracker;
    private FollowManager followManager;
    private FoxMovement foxMovement;
    private bool started;
    private float timer;

    // Find the FollowManager script and assign to followManager
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
        foxMovement = FindObjectOfType<FoxMovement>();
    }

    private void Start()
    {
        retry.onClick.AddListener(RetryClicked);
        start.onClick.AddListener(StartClicked);
        listTracker = followManager.collectedFoxes.Count;
    }

    private void Update()
    {
        if (started == true)
        {
            timer += Time.deltaTime;

            // timerText.SetText("Timer: " + FloatTimeConvert(timer) + " / " + IntTimeConvert(levelTime));
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

    void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void StartClicked()
    {
        started = true;
        foxMovement.isControlling = true;
        start.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        disclaimer.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        // timerText.gameObject.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            foxlingCounter[i].gameObject.SetActive(true);
        }
    }

    // Captured method that displays captured text
    public void Captured()
    {
        captured.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);
    }

    public void FinishGame()
    {
        congrats.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

        if (timer < levelTime)
        {
            stars.SetText("AAA");
        }
        else
        {
            stars.SetText("AA");
        }

        stars.gameObject.SetActive(true);
    }

    private string IntTimeConvert(int time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);

        const string Format = "{1:D2}:{2:D2}";
        string answer = string.Format(Format, t.Minutes, t.Seconds);

        return answer;
    }

    private string FloatTimeConvert(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(Mathf.RoundToInt(time));

        const string Format = "{1:D2}:{2:D2}";
        string answer = string.Format(Format, t.Minutes, t.Seconds);

        return answer;
    }
}
