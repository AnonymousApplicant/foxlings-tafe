using UnityEngine;

/// <summary>
/// Manages the movement and physics of the Fox (player)
/// </summary>
public class FoxMovement : MonoBehaviour
{
    public float gravity; // Value that is acting like gravity
    public float moveSpeed; // Normal movement speed
    public float dashSpeed; // Dash movement speed
    public float rotSpeed; // Speed at which Fox will rotate
    public float checkRadius; // Radius of the groundCheckObj
    public GameObject groundCheckObj; // The gameObject that is the groundCheckObj

    private float velocity; // The value that tracks the velocity of the player
    private float currentSpeed; // Keeps track of the current speed of the player
    private Vector3 targetDir; // (NOT IN USE RIGHT NOW) The direction the player is currently targeting
    private Vector3 currentDir; // (NOT IN USE RIGHT NOW) The current direction the player is looking in
    private bool isGrounded; // Keeps track of whether or not the player is touching the ground
    private CharacterController controller; // Variable that contains the character controller component

    void Start()
    {
        // Assign controller to variable
        controller = gameObject.GetComponent<CharacterController>();
        // Set current speed to moveSpeed default
        currentSpeed = moveSpeed;
    }

    // Check inputs and apply gravity and movement
    void Update()
    {
        // Input variable booleans
        bool f = Input.GetButton("Forwards");
        bool b = Input.GetButton("Backwards");
        bool l = Input.GetButton("Left");
        bool r = Input.GetButton("Right");

        // Assign isGrounded, check if the groundCheckObj is touching any onj in "Ground" layer
        isGrounded = Physics.CheckSphere(groundCheckObj.transform.position, checkRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        // Create and assign the move variable
        Vector3 move = Vector3.zero;

        // Check if isGrounded, adjust velocity value based on true or false
        if (isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }

        // Send position, velocity variables and inputs to method
        ApplyMovement(move, velocity, f, b, l, r);
    }

    /// <summary>
    /// Figures out direction being inputted, applies movement and gravity to character controller.
    /// </summary>
    void ApplyMovement(Vector3 position, float velocity, bool forwards, bool backwards, bool left, bool right)
    {
        // If opposite keys are being pressed, do nothing
        if (forwards && backwards || left && right)
        {
            return;
        }
        // Up & Left (Apply Rotation)
        if (forwards && left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -45;
            transform.eulerAngles = rot;
        }
        // Up & Right (Apply Rotation)
        else if (forwards && right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 45;
            transform.eulerAngles = rot;
        }
        // Down & Left (Apply Rotation)
        else if (backwards && left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -135;
            transform.eulerAngles = rot;
        }
        // Down & Right (Apply Rotation)
        else if (backwards && right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 135;
            transform.eulerAngles = rot;
        }
        // Down (Apply Rotation)
        else if (backwards)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 180;
            transform.eulerAngles = rot;
        }
        // Up (Apply Rotation)
        else if (forwards)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 0;
            transform.eulerAngles = rot;
        }
        // Left (Apply Rotation)
        else if (left)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -90;
            transform.eulerAngles = rot;
        }
        // Right (Apply Rotation)
        else if (right)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 90;
            transform.eulerAngles = rot;
        }

/*          (NOT IMPLEMENTED YET)
        currentDir = transform.eulerAngles;

        if (currentDir.y != targetDir.y)
        {
            currentDir.y += rotSpeed;
            transform.eulerAngles = currentDir;
        }
*/

        // If any input key is pressed, update position variable
        if (forwards || backwards || left || right)
        {
            position += transform.forward * currentSpeed * Time.deltaTime;
        }
        // Update gravity on Y axis
        position.y += velocity * Time.deltaTime;
        // Send position to character controller
        controller.Move(position);
    }

    // For visualising the groundCheckObj sphere in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheckObj.transform.position, checkRadius);
    }
}
