using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public Slider loadingSlider;
    public TMP_Text textoPorcentagem;

    public static string nomeDaNovaCena;

    void Start()
    {
        StartCoroutine(CarregarCenaAsync());
    }

    IEnumerator CarregarCenaAsync()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(nomeDaNovaCena);

        operacao.allowSceneActivation = false;

        while (!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            if (loadingSlider != null)
            {
                loadingSlider.value = progresso;
            }

            if (textoPorcentagem != null)
            {
                textoPorcentagem.text = (progresso * 100f).ToString("0") + "%";
            }

            if (operacao.progress >= 0.9f)
            {
                operacao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}