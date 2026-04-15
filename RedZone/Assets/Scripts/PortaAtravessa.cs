using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaAtravessa : MonoBehaviour
{
    InventarioJogador inventario;
    void Start()
    {
        inventario = FindAnyObjectByType<InventarioJogador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (inventario.chaveUm == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Pode não mn");
        }
    }
}
