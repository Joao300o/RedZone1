using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class InventarioJogador : MonoBehaviour
{
    public bool chaveUm = false;
    public bool chaveDois = false;

    public TiroJogador[] tiroJogador;

    //TiroJogador tiroJogador;

    PlayerVida vidaJogador;

    public TMP_Text possuiChave;

    void Start()
    {
        vidaJogador = GetComponent<PlayerVida>();
        //tiroJogador = GetComponentInChildren<TiroJogador>();
    }

    public void ColetaItem(TipoItem item)
    {
        switch (item)
        {
            case TipoItem.chaveUm:
                chaveUm = true;
                StartCoroutine(MostrarChave("Você possui uma chave.", 3f));
                break;

            case TipoItem.vida:
                vidaJogador.Curar(20);
                break;

            case TipoItem.chaveDois:
                chaveDois = true;
                break;

            case TipoItem.municaoArma:
                foreach (TiroJogador tiro in tiroJogador)
                {
                    tiro.Municao(Random.Range(6, 10));
                }
                break;
        }
    }
    IEnumerator MostrarChave(string msgChave, float duracaoChave)
    {
        possuiChave.text = msgChave;
        possuiChave.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracaoChave);

        possuiChave.gameObject.SetActive(false);
    }
}
