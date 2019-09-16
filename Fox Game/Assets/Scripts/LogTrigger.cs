using UnityEngine;

/// <summary>
/// Manages log animation and triggers
/// </summary>
public class LogTrigger : MonoBehaviour
{
    public GameObject notifier; // Game Object variable that contains the notification image for the log
    public GameObject tooltip; // Game Object variable that contains the tooltip image for the log

    private HUDManager hud; // Variable for the HUDManager script
    private FollowManager followManager; // Variable for the follow manager script
    private bool triggered; // Variable to keep track of whether the log has been triggered or not

    // Find the FollowManager and HUD script and assign them
    private void Start()
    {
        hud = FindObjectOfType<HUDManager>();
        followManager = FindObjectOfType<FollowManager>();
    }

    // If the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (followManager.collectedFoxes.Count < 3)
            {
                // If the player does not have the the right amount of foxlings, notify them
                notifier.SetActive(true);
            }
            else
            {
                // Else if they do show them the interact tooltip
                tooltip.SetActive(true);
            }
        }
    }

    // If the log has not been triggered yet, player has 2 foxlings, object is player and interact button pressed then...
    private void OnTriggerStay(Collider other)
    {
        if (triggered == false)
        {
            if (followManager.collectedFoxes.Count == 3)
            {
                if (other.tag == "Player")
                {
                    if (Input.GetButton("Interact") == true)
                    {
                        // Trigger log animation
                        GetComponentInParent<Animator>().SetTrigger("triggerLog");
                        // Set triggered to true so cant be triggered again
                        triggered = true;
                        // Remove tooltip
                        tooltip.SetActive(false);
                    }
                }
            }
        }
    }

    // When the player leaves, make sure the images have been disabled
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        { 
            notifier.SetActive(false);
            tooltip.SetActive(false);
        }
    }
}
