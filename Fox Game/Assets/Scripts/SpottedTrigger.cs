using UnityEngine;

/// <summary>
/// Manages the vision trigger and end game
/// </summary>
public class SpottedTrigger : MonoBehaviour
{
    public HUDManager hud; // HUDManager script variable
    private FollowManager followManager; // FollowManager script variable

    // Find the FollowManager script and assign to followManager
    private void Start()
    {
        followManager = FindObjectOfType<FollowManager>();
    }

    // Execute Caught() method if something triggers the vision trigger
    private void OnTriggerEnter(Collider other)
    {
        Caught(other.gameObject);
    }

    /// <summary>
    /// Checks if the obj is player or foxling, if so remove foxlings and characters in list
    /// </summary>
    private void Caught(GameObject obj)
    {
        // Check if triggered by player or foxlings
        if (obj.tag == "Player" || obj.tag == "Foxling")
        {
            // disable objs in fox list
            foreach (GameObject fox in followManager.collectedFoxes)
            {
                fox.gameObject.SetActive(false);
            }

            // Execute captured method
            hud.Captured();
        }
    }
}
