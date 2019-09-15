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

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            TransparentObj obj = hit.collider.GetComponent<TransparentObj>();
            if (obj == false)
            {
                return;
            }
            else
            {
                obj.isTransparent = true;
            }
        }
    }
}
