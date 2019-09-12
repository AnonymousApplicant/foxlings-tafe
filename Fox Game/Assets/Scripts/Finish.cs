using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private FollowManager followManager;
    public HUDManager hud; // HUDManager script variable

    // Find the FollowManager script and assign to followManager
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
        hud = FindObjectOfType<HUDManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (followManager.collectedFoxes.Count == 4)
        {
            hud.FinishGame();
        }
    }
}
