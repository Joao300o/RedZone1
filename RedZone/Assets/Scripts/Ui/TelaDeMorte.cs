using UnityEngine;
using UnityEngine.SceneManagement;


public class TelaDeMorte : MonoBehaviour
{
    public GameObject telaDeMorte;

    public CameraHorizontal cameraHorizontal;
    public TiroJogador[] armas;

    public PlayerVida vidaJogadorJogo;
    public PauseMenu pauseMenu;
    public GameObject mira;

    private bool morto = false;



    void Update()
    {
        if (vidaJogadorJogo.vidaAtual <= 0 && !morto)
        {
            morto = true;
            Morreu();
        }
    }

    private void Morreu()
    {
        foreach (TiroJogador arma in armas)
        {
            arma.enabled = false;
        }

        mira.SetActive(false);
        pauseMenu.enabled = false;
        cameraHorizontal.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        telaDeMorte.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetBTN()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1f;

        LoadingManager.nomeDaNovaCena = "Menu";
        SceneManager.LoadScene("Loading");
    }
}
