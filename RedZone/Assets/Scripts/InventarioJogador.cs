using UnityEngine;

public class InventarioJogador : MonoBehaviour
{
  public bool chaveUm = false;
  public bool chaveDois = false;

  TiroJogador tiroJogador;
  
  PlayerVida vidaJogador;

  void Start()
    {
    vidaJogador = GetComponent<PlayerVida>();
    tiroJogador = GetComponent <TiroJogador>();
    }

    public void ColetaItem(TipoItem item)
    {
        switch(item)
        {
            case TipoItem.chaveUm:
            chaveUm = true;
            Debug.Log("você tem a chave um");
            break;

            case TipoItem.vida:
            vidaJogador.Curar(20);
            break;

            case TipoItem.chaveDois:
            chaveDois = true;
            break;

            case TipoItem.municaoArma:
            tiroJogador.Municao(1);
            break;
        }
    }
}
