using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    public List<Vector3> storedPositions;
    public List<Vector3> storedRotations;
    public int amount = 0;

    void Awake()
    {
        storedPositions = new List<Vector3>();
        storedRotations = new List<Vector3>();
    }

    void Update()
    {
        bool f = Input.GetButton("Forwards");
        bool b = Input.GetButton("Backwards");
        bool l = Input.GetButton("Left");
        bool r = Input.GetButton("Right");

        if (f || b || l || r)
        {
            storedPositions.Add(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z));
            storedRotations.Add(new Vector3(transform.eulerAngles.x - 90f, transform.eulerAngles.y, transform.eulerAngles.z));
        }

        if (storedPositions.Count > 46)
        {
            storedPositions.RemoveAt(0);
        }

        if (storedRotations.Count > 46)
        {
            storedRotations.RemoveAt(0);
        }
    }
}
