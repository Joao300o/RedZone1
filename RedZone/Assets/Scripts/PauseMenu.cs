using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    public CameraHorizontal cameraHorizontal;
    private bool pausado = false;

    void Start()
    {
        HidePausedMenu();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
                HidePausedMenu();
            else
                ShowPauseMenu();
        }
    }

    public void Continuar()
    {
        HidePausedMenu();
    }

    private void HidePausedMenu()
    {
        cameraHorizontal.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausado = false;
        menuPause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ShowPauseMenu()
    {
        cameraHorizontal.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pausado = true;
        menuPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
