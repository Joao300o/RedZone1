using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public float sensitivityX = 1f;
    // public float sensitivityY = 1f;

    float rotationX = 0;
    float rotationY = 0;
    // float angleYmin = -90;
    // float angleYmax = 90;

   

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
private void LateUpdate()
    {
        transform.position = characterHead.position;
    }
    void Update()
    {
        // float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        rotationX += horizontalDelta;
        // rotationY += verticalDelta;

        // rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
