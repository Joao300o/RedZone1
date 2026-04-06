using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Net.Http.Headers;
using System;

public class LoadingScene : MonoBehaviour
{
    public void CarregarNovaCena(string nomeDaNovaCena)
    {
        StartCoroutine(CarregarNovaCenaEmSegundoPlano(nomeDaNovaCena));
    }

    private IEnumerator CarregarNovaCenaEmSegundoPlano(string nomeDaNovaCena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(nomeDaNovaCena);

        while (!carregamento.isDone)
        {
            float progressoDoCarregamento = carregamento.progress;


            yield return null;
        }
    }
}