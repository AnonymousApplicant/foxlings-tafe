using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    public float gravity;
    public float moveSpeed;
    public float dashSpeed;
    public float rotSpeed;
    public float checkRadius;
    public GameObject groundCheckObj;

    private float velocity;
    private Vector3 targetDir;
    private Vector3 currentDir;
    private bool isGrounded;
    private float currentSpeed;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = moveSpeed;
        currentDir = transform.eulerAngles;
        targetDir = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        bool f = Input.GetButton("Forwards");
        bool b = Input.GetButton("Backwards");
        bool l = Input.GetButton("Left");
        bool r = Input.GetButton("Right");

        isGrounded = Physics.CheckSphere(groundCheckObj.transform.position, checkRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        Vector3 move = Vector3.zero;

        if (isGrounded)
        {
            velocity = -gravity * Time.deltaTime;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }

        ApplyMovement(move, velocity, f, b, l, r);
    }

    void ApplyMovement(Vector3 position, float velocity, bool forwards, bool backwards, bool left, bool right)
    {
        // Opposites
        if (forwards && backwards || left && right)
        {
            return;
        }

        // Up & Left
        if (forwards && left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -45;
            transform.eulerAngles = rot;
        }
        // Up & Right
        else if (forwards && right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 45;
            transform.eulerAngles = rot;
        }
        // Down & Left
        else if (backwards && left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -135;
            transform.eulerAngles = rot;
        }
        // Down & Right
        else if (backwards && right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 135;
            transform.eulerAngles = rot;
        }
        // Down
        else if (backwards)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 180;
            transform.eulerAngles = rot;
        }
        // Up
        else if (forwards)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 0;
            transform.eulerAngles = rot;
        }
        else if (left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -90;
            transform.eulerAngles = rot;
        }
        else if (right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 90;
            transform.eulerAngles = rot;
        }

/*
        currentDir = transform.eulerAngles;

        if (currentDir.y != targetDir.y)
        {
            currentDir.y += rotSpeed;
            transform.eulerAngles = currentDir;
        }
*/

        if (forwards || backwards || left || right)
        {
            position += transform.forward * currentSpeed * Time.deltaTime;
        }

        position.y += velocity * Time.deltaTime;
        controller.Move(position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheckObj.transform.position, checkRadius);
    }
}
