using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject configuracaoPanel;
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

    public void Sair()
    {
        Application.Quit();
    }
}
