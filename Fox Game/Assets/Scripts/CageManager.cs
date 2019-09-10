using UnityEngine;

/// <summary>
/// Manages the collecting of Foxlings from cages, and adds them to the collectedList. Handles cage animation.
/// </summary>
public class CageManager : MonoBehaviour
{
    public GameObject foxling; // Foxling GameObject that is inside the cage this script is attached to
    public bool collected; // Boolean to check if Foxling has been collected yet

    private FollowManager followManager; // FollowManager script variable

    // Find the FollowManager script and assign to followManager
    private void Start()
    {
        followManager = FindObjectOfType<FollowManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger has triggered already
        if (collected == false)
        {
            // Check if the player triggered it
            if (other.tag == "Player")
            {
                // Trigger cage animation
                GetComponentInParent<Animator>().SetTrigger("triggerCage");
                // Set Foxling to follow
                foxling.GetComponent<FollowMovement>().isFollowing = true;
                // Add Foxling to collectedFoxes list
                followManager.collectedFoxes.Add(foxling.gameObject);
                // Set collected to true so the first if wont trigger again
                collected = true;
            }
        }
    }
}
