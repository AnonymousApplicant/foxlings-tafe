using UnityEngine;

/// <summary>
/// Manages how to player camera moves
/// </summary>
public class CameraController : MonoBehaviour
{
    public Vector3 rotOffset; // Rotation offset
    public Vector3 posOffset; // Position offset
    public Transform target; // Target object to offset camera from

    private void Awake()
    {
        // Set camera angle to rotational offset 
        transform.eulerAngles = rotOffset;
    }

    void Update()
    {
        // Update camera position to target position and apply posOffset
        transform.position = target.position + posOffset;
    }
}
