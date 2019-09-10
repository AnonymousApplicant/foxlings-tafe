using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the rotation and position lists, Fox list and updates storedRotation/Position lists
/// </summary>
public class FollowManager : MonoBehaviour
{
    public int maxCount; // Variable that caps storedPositions/Rotations list
    public List<Vector3> storedPositions; // Keeps track of the last 45 frames of the players position
    public List<Vector3> storedRotations; // Keeps track of the last 45 frames of the players rotation
    public List<GameObject> collectedFoxes; // Keeps track of the player and any collected Foxlings

    void Awake()
    {
        // Assign the storedPositions/Rotations variable a new Vector3 list
        storedPositions = new List<Vector3>();
        storedRotations = new List<Vector3>();
        // Assign the collectedFoxes variable a new GameObject list and add the player object to it
        collectedFoxes = new List<GameObject>();
        collectedFoxes.Add(gameObject);
    }

    void Update()
    {
        // Update input booleans
        bool f = Input.GetButton("Forwards");
        bool b = Input.GetButton("Backwards");
        bool l = Input.GetButton("Left");
        bool r = Input.GetButton("Right");

        // Check if any input is true (pressed), if so add a new position and rotation to respective list
        if (f == true || b == true || l == true || r == true)
        {
            storedPositions.Add(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z));
            storedRotations.Add(new Vector3(transform.eulerAngles.x - 90f, transform.eulerAngles.y, transform.eulerAngles.z));
        }

        // If storedPositions has more than 45 items, delete the oldest item
        if (storedPositions.Count > maxCount)
        {
            storedPositions.RemoveAt(0);
        }

        // If storedRotations has more than 45 items, delete the oldest item
        if (storedRotations.Count > maxCount)
        {
            storedRotations.RemoveAt(0);
        }
    }
}
