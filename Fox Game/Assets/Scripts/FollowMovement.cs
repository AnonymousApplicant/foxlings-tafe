using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    public bool isFollowing;

    private FollowManager main;
    private bool assigned;
    private int position;

    void Awake()
    {
        main = FindObjectOfType<FollowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing == true)
        {
            if (assigned == false)
            {
                if (main.amount == 2)
                {
                    position = 10;
                    assigned = true;
                    main.amount++;
                }
                else if (main.amount == 1)
                {
                    position = 20;
                    assigned = true;
                    main.amount++;
                }
                else
                {
                    position = 30;
                    assigned = true;
                    main.amount++;
                }
            }

            bool f = Input.GetButton("Forwards");
            bool b = Input.GetButton("Backwards");
            bool l = Input.GetButton("Left");
            bool r = Input.GetButton("Right");

            if (f || b || l || r)
            {
                transform.position = main.storedPositions[position];
                transform.eulerAngles = main.storedRotations[position];
            }
        }
    }
}
