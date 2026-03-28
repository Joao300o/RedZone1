using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    public static string proximaCena;
    public Slider barra;

    void Start()
    {
        StartCoroutine(CarregarCena());
    }

    IEnumerator CarregarCena()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(proximaCena);

        operacao.allowSceneActivation = false;

        while (!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            barra.value = progresso;

            if (operacao.progress >= 0.9f)
            {
                barra.value = 1f;

                yield return new WaitForSeconds(0.5f);

                operacao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}