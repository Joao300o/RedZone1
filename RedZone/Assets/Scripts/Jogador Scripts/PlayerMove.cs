using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float speedSprint = 8f;
    private float current;
    public float gravity = -20f;

    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;

    public float volumeCorrendo;
    public float volumeAndando;
    public AudioManager audioManager;
    public AudioClip andando;
    public AudioClip correndo;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        current = speed;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * v + right * h).normalized;

        bool movendo = direction.magnitude > 0 && controller.isGrounded;

        if (movendo)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                current = speedSprint;
                if (audioManager.audioSourcePassos.clip != correndo)
                    audioManager.PararPassos();
                audioManager.TocarPassos(correndo, volumeCorrendo, 0.8f);
            }
            else
            {
                current = speed;
                if (audioManager.audioSourcePassos.clip != andando)
                    audioManager.PararPassos();
                audioManager.TocarPassos(andando, volumeAndando, 1.3f);
            }
        }
        else
        {
            current = speed;
            audioManager.PararPassos();
        }

        Vector3 move = direction * current;

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;

        controller.Move((move + velocity) * Time.deltaTime);
    }
}