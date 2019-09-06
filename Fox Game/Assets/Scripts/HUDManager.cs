using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI captured;

    public void Captured()
    {
        captured.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
