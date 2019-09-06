using System.Collections.Generic;
using UnityEngine;

public class SpottedTrigger : MonoBehaviour
{
    public HUDManager hud;

    public List<GameObject> foxlings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject fox in foxlings)
            {
                fox.gameObject.SetActive(false);
            }

            other.gameObject.SetActive(false);
            hud.Captured();
        }
    }
}
