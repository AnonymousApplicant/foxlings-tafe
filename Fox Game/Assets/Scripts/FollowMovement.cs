using UnityEngine;

/// <summary>
/// Manages the movement and positioning of the Foxlings and removal of the exclamation mark
/// </summary>
public class FollowMovement : MonoBehaviour
{
    public bool isFollowing; // Keeps track if Foxling is currently following
    public GameObject exclamation; // Holds the gameObject for the exclamation above the foxling

    private FollowManager followManager; // FollowManager script variable
    private bool assigned = false; // Keeps track if the foxling has assigned itself to the conga line
    private int position; // Keeps track of what position the foxling is in the conga line (what list element they grab from)
    private int waitCount = 0; // Keeps track of how many frames have passed since collection
    private bool collected = false; // Keeps track of if the foxling got collected

    // Find the FollowManager script and assign to followManager
    void Awake()
    {
        followManager = FindObjectOfType<FollowManager>();
    }

    void Update()
    {
        // Check if the foxling is following, otherwise do nothing
        if (PauseMenu.isPaused == false && isFollowing == true)
        {
            // Check if collected = false, if it does deactivate the exclamation object then set collected to true
            if (collected == false)
            {
                exclamation.gameObject.SetActive(false);
                collected = true;
            }
            
            // If foxling has not been assigned, assign it a position based on currect list of foxlings
            if (assigned == false)
            {
                // If collectedFoxes includes player and 2 foxlings, assign 3rd position
                if (followManager.collectedFoxes.Count == 4)
                {
                    position = 5;
                    assigned = true;
                }
                // If collectedFoxes includes player and 1 foxling, assign 2nd position
                else if (followManager.collectedFoxes.Count == 3)
                {
                    position = (followManager.framesPerGap + 3);
                    assigned = true;
                }
                // If collectedFoxes includes only player, assign 1st position
                else if (followManager.collectedFoxes.Count == 2)
                {
                    position = (2 * followManager.framesPerGap);
                    assigned = true;
                }
            }

            // If waitCount is less than its position, do not update position
            if (waitCount < position)
            {
                waitCount++;
            }
            else
            {
                // get input booleans
                bool f = Input.GetButton("Forwards");
                bool b = Input.GetButton("Backwards");
                bool l = Input.GetButton("Left");
                bool r = Input.GetButton("Right");

                // Check if any input is being pressed, if so update rotation and position
                if (f || b || l || r)
                {
                    transform.position = followManager.storedPositions[position];
                    transform.eulerAngles = followManager.storedRotations[position];
                }
            }
        }
    }
}
