using UnityEngine;

public class CameraHorizontal : MonoBehaviour
{
    public Transform characterBody; // Corpo do personagem
    public Transform characterHead; // Cabeça do Personagem

    public float sensitivityX = 1f; // Sensibilidade da camera 

    float rotationX = 0; // rotação da camera no eixo X

    void Start()
    {
        Cursor.visible = false; //Desabilita o curso
        Cursor.lockState = CursorLockMode.Locked; // Vai travar o curso ao iniciar o jogo
    }
private void LateUpdate() // É executado depois do update
    {
        transform.position = characterHead.position; // define que a posição do transform onde vai está armazenado o scripts será igual 
    }
    void Update()
    {

      float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX;

        rotationX += mouseX;

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
    }
}
