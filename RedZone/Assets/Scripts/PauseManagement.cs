using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManagement : MonoBehaviour
{
    public GameObject menuPause;
    public MonoBehaviour cameraScript;
    private bool pausado = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }
    public void Continuar()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cameraScript.enabled = true;
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }
    
    public void Pausar()
    {
        cameraScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        menuPause.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void voltarMenu()
    {
        LoadingScene.proximaCena = "Menu";
        SceneManager.LoadScene(1);
    }

    
    public void SairUm()
    {
        Application.Quit();
    } 
}
