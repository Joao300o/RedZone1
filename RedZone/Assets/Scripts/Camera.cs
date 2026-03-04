using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform characterBody; // Corpo do personagem
    public Transform characterHead; // Cabeça do Personagem

    public float sensitivityX = 1f; // Sensibilidade da camera 

    float rotationX = 0; // rotação da camera no eixo X
    float rotationY = 0; // rotação da camera no eixo Y


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

        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX; // pega o movimento cru do mouse atraves do GetAxisRaw, ajusta a sensibilidade e prepara para rodar o objeto horizontalvente no jogo

        rotationX += horizontalDelta; //

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0); // 

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0); // 
    }
}
