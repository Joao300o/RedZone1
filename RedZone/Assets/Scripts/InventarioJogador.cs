using UnityEngine;

public class InventarioJogador : MonoBehaviour
{
  public bool chaveUm = false;
  public bool chaveDois = false;
  
  PlayerVida vidaJogador;

  void Start()
    {
    vidaJogador = GetComponent<PlayerVida>();
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


        }
    }
}
