using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;


public class PortaAtravessa : MonoBehaviour
{
    InventarioJogador inventario;

    public TMP_Text textoAviso;
    void Start()
    {
        inventario = FindAnyObjectByType<InventarioJogador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (inventario.chaveUm == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
            LoadingManager.nomeDaNovaCena = "Menu";
            SceneManager.LoadScene("Loading");
        }
        else
        {
            StartCoroutine(MostrarAviso("Você precisa da chave do elevador para usá-lo.", 3f));
        }
    }
    IEnumerator MostrarAviso(string msg, float duracao)
    {
        textoAviso.text = msg;
        textoAviso.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracao);

        textoAviso.gameObject.SetActive(false);
    }
}
