using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float forwardSpeed = 5f;
    float strafeSpeed = 5f;

    float grvaity;
    float timeToMaxHeight = 0.5f;
    float maxJumpHeight = 2f;

      CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        grvaity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
    }
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

    forward = forwardInput * forwardSpeed * transform.forward;
    strafe = strafeInput * strafeSpeed * transform.right;

    if(controller.isGrounded)
        {
            vertical = Vector3.down;
        }

    vertical += grvaity * Time.deltaTime * Vector3.up;

    Vector3 finalVelocity = forward + strafe + vertical;

    controller.Move(finalVelocity * Time.deltaTime);    
    }
}
