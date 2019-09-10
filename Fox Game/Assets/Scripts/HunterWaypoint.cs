using UnityEngine;

/// <summary>
/// Manages the hunter waypoint patrol system
/// </summary>
public class HunterWaypoint : MonoBehaviour
{
    public GameObject[] waypoints; // List of waypoints for patrol
    public int num = 0; // Keeps track of current waypoint
    public float rotAngle; // The angle hunter should rotate (CW) each time they get to a waypoint
    public float minDist; // The minimum distance the hunter can be from a waypoint before switching
    public float speed; // The speed at which the hunter moves

    void Update()
    {
        // Get distance between hunter and next waypoint
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        // If the distance away is greater than the minDist, Execute Move() method
        if (dist > minDist)
        {
            Move();
        }
        else
        // Else if hunter is within min distance
        {
            // Check if next waypoint exist, if current waypoint is last set back to 0
            if (num + 1 == waypoints.Length)
            {
                num = 0;
            }
            // Else
            else
            {
                // +1 to num
                num++;
            }
            // Apply rotation
            Vector3 r = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotAngle, transform.eulerAngles.z);
            transform.eulerAngles = r;
        }
    }

    /// <summary>
    /// Moves the hunter towards next waypoint
    /// </summary>
    public void Move()
    {
        // Assign tPos to position of next waypoint
        Vector3 tPos = new Vector3(waypoints[num].transform.position.x , waypoints[num].transform.position.y, waypoints[num].transform.position.z);
        // Move hunter forward at set speed
        gameObject.transform.position += (waypoints[num].transform.position - transform.position) * speed * Time.deltaTime;
    }

}
