using UnityEngine;

public class LogTrigger : MonoBehaviour
{
    private HUDManager hud;
    private FollowManager followManager;
    private bool triggered;

    // Find the FollowManager script and assign to followManager
    private void Start()
    {
        hud = FindObjectOfType<HUDManager>();
        followManager = FindObjectOfType<FollowManager>();
    }

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
                        triggered = true;
                    }
                }
            }
            else
            {
                hud.GetComponentInChildren<Animator>().SetTrigger("triggerIcon");
            }
        }
    }
}
