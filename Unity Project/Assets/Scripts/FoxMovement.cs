using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    public float gravity;
    public float moveSpeed;
    public float dashSpeed;
    public float jumpForce;
    public float checkRadius;
    public GameObject groundCheckObj;

    private float velocity;
    private bool isGrounded;
    private float currentSpeed;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckObj.transform.position, checkRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        Vector3 move = Vector3.zero;
        float v = Input.GetAxis("Vertical") * currentSpeed;
        float h = Input.GetAxis("Horizontal") * currentSpeed;

        if (isGrounded)
        {
            velocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                velocity = jumpForce;
            }
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }

        ApplyMovement(move, velocity, v, h);
    }

    void ApplyMovement(Vector3 position, float velocity, float vertical, float horizontal)
    {
        if (vertical > 0.9)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 0;
            transform.eulerAngles = rot;
            position += transform.forward * currentSpeed * Time.deltaTime;
        }
        if (vertical < -0.9)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 180;
            transform.eulerAngles = rot;
            position += transform.forward * currentSpeed * Time.deltaTime;
        }
        if (horizontal > 0.9)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = 90;
            transform.eulerAngles = rot;
            position += transform.forward * currentSpeed * Time.deltaTime;
        }
        if (horizontal < -0.9)
        {
            Vector3 rot = transform.eulerAngles;
            rot.y = -90;
            transform.eulerAngles = rot;
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
