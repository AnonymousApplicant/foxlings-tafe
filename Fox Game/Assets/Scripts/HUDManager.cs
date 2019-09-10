using TMPro;
using UnityEngine;

/// <summary>
/// Manages the HUD
/// </summary>
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI captured; // Captured text for when you or your foxlings are captured

    // Captured method that displays captured text
    public void Captured()
    {
        captured.gameObject.SetActive(true);
    }
}
