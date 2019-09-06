using UnityEngine;

public class CageManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInParent<Animator>().SetTrigger("triggerCage");
            GetComponentInChildren<FollowMovement>().isFollowing = true;
        }
    }
}
