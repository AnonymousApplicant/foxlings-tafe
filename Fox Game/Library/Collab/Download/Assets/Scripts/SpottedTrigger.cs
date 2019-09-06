using UnityEngine;

public class SpottedTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }
    }
}
