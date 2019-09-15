using UnityEngine;

public class LogTrigger : MonoBehaviour
{
    public GameObject notifier;
    public GameObject tooltip;

    private HUDManager hud;
    private FollowManager followManager;
    private bool triggered;

    // Find the FollowManager script and assign to followManager
    private void Start()
    {
        hud = FindObjectOfType<HUDManager>();
        followManager = FindObjectOfType<FollowManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (followManager.collectedFoxes.Count < 3)
            {
                notifier.SetActive(true);
            }
            else
            {
                tooltip.SetActive(true);
            }
        }
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
                        tooltip.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (followManager.collectedFoxes.Count < 3)
        {
            notifier.SetActive(false);
        }
        else
        {
            tooltip.SetActive(false);
        }
    }
}
