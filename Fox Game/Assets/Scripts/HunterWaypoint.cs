using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterWaypoint : MonoBehaviour
{
    /// <summary>
    /// 1. Rotate and move in direction of another waypoint once first waypoint has been reached. 'rotAngle'
    /// 2. Manage distance from waypoint before turn occurs. 'minDist'
    /// 3. Manage speed of individual bunnies movement. 'speed'
    /// 4. True or False (bool)variables for bunnies to move between waypoints. 'go'
    /// 5. True or False (bool)variables for bunnies path to be random between waypoints. 'rand'
    /// </summary>
    public GameObject[] waypoints;
    public int num = 0;

    public float rotAngle = 90;
    public float minDist;
    public float speed;

    public bool go = true;

    /// <summary>
    /// 1. Calculate distance between a Bunny and the waypoint its heading towards. <para />
    /// 2a. Check if Bunny is able to move (go = true)
    ///     - If distance is greater then the minimum distance then bunny is allowed to move. 
    ///     - If minimum distance is greater than distance then bunny continues to 'else'.
    ///         - else: If rand = false then bunny moves to waypoint next in array.
    ///         - else: If rand = false and the bunny has reach the final waypoint in array bunny reverts back to its orginal waypoint. <para />
    /// 2b. Check if Bunny is set move (go = true) and set to choose random waypoint (rand = true)
    ///     - If rand = true, Bunny selects a random number in the range of 0 - final way point in array.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (go)
        {
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                if (num + 1 == waypoints.Length)
                {
                    num = 0;
                }
                else
                {
                    num++;
                }

                /// <summary>
                /// 1.Bunny will then go through the functions of rotating.
                /// 2.Rotating Bunny towards the next waypoint to then move forward.
                /// </summary>
                Vector3 r = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotAngle, transform.eulerAngles.z);
                transform.eulerAngles = r;
            }
        }

           
    }
    /// <summary>
    /// 1. If Bunny can move (go = true) if distance is greater than minimum distance.
    /// </summary>
    public void Move()
    {
        Vector3 tPos = new Vector3(waypoints[num].transform.position.x , waypoints[num].transform.position.y, waypoints[num].transform.position.z);
        //gameObject.transform.LookAt(tPos);
        gameObject.transform.position += (waypoints[num].transform.position - transform.position) * speed * Time.deltaTime;
    }

}
