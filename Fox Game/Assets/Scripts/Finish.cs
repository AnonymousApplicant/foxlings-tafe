using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private FollowManager followManager;
    public HUDManager hud; // HUDManager script variable

    // Find the FollowManager script and assign to followManager, do the same with hud but for HUDManager
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
        hud = FindObjectOfType<HUDManager>();
    }

    // If player has all pups and steps into trigger, finish game :D
    private void OnTriggerEnter(Collider other)
    {
        if (followManager.collectedFoxes.Count == 4 && other.tag == "Player")
        {
            hud.FinishGame();
        }
    }
}
