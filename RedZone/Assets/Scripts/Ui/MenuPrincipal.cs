using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject configuracaoPanel;
    public GameObject tutorialPanel;

    public Slider sliderVolume;
    public Slider sliderSensi;

    public TMP_Text volumeTxt;
    public TMP_Text sensiTxt;

    void Start()
    {
        sliderVolume.value = ConfiguracaoJogo.CarregarVolume();
        sliderSensi.value = ConfiguracaoJogo.CarregarSensi();
        AudioListener.volume = sliderVolume.value / 100f;
    }

    public void Jogar()
    {
        LoadingManager.nomeDaNovaCena = "Trilha Radioativa";
        SceneManager.LoadScene("Loading");
    }

    public void AbrirConfiguracao()
    {
        mainMenu.SetActive(false);
        configuracaoPanel.SetActive(true);
    }

    public void FecharConfiguracao()
    {
        configuracaoPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void AbrirTutorial()
    {
        mainMenu.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void FecharTutorial()
    {
        tutorialPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SensiManager()
    {
        sensiTxt.text = "Sensibilidade: " + sliderSensi.value.ToString("F1");
        ConfiguracaoJogo.SalvarSensi(sliderSensi.value);
    }

    public void VolumeManager()
    {
        AudioListener.volume = sliderVolume.value / 100f;
        volumeTxt.text = "Volume: " + sliderVolume.value.ToString("F0");
        ConfiguracaoJogo.SalvarVolume(sliderVolume.value);
    }

    public void Sair()
    {
        Application.Quit();
    }
}