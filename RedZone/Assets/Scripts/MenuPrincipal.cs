using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject configuracaoPanel;
    public GameObject tutorialPanel;

    public void Jogar()
    {
        LoadingManager.nomeDaNovaCena = "Trilha Radioativa";
        SceneManager.LoadScene("Loading");
    }

    //Configuração
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

    //Tutorial
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

    public void Sair()
    {
        Application.Quit();
    }
}
