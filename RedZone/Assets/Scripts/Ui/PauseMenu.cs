using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject opcoesPanel;
    public GameObject canvaUI;

    public CameraHorizontal cameraHorizontal;

    private bool pausado = false;

    public Slider sliderVolume;
    public Slider sliderSensi;

    public TMP_Text volumeTxt;
    public TMP_Text sensiTxt;

    public TiroJogador[] armas;

    public GameObject mira;

    void Start()
    {
        pausado = false;

        menuPause.SetActive(false);
        opcoesPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        sliderSensi.value = cameraHorizontal.sensitivityX;
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
        opcoesPanel.SetActive(false);
        Time.timeScale = 1f;
        mira.SetActive(true);

        foreach (TiroJogador arma in armas)
        {
            arma.enabled = true;
        }
    }

    private void ShowPauseMenu()
    {
        foreach (TiroJogador arma in armas)
        {
            arma.enabled = false;
        }

        mira.SetActive(true);
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

    public void GoMainMenu()
    {
        Time.timeScale = 1f;


        LoadingManager.nomeDaNovaCena = "Menu";
        SceneManager.LoadScene("Loading");
    }

    public void ShowOption()
    {
        menuPause.SetActive(false);
        opcoesPanel.SetActive(true);
        canvaUI.SetActive(false);
    }

    public void HideOption()
    {
        opcoesPanel.SetActive(false);
        menuPause.SetActive(true);
        canvaUI.SetActive(true);
    }

    public void SensiManager()
    {
        cameraHorizontal.sensitivityX = sliderSensi.value;

        sensiTxt.text = "Sensibilidade: " + sliderSensi.value.ToString("F1");
    }

    public void VolumeManager()
    {

    }
}
