using UnityEngine;

public class ArmaJogador : MonoBehaviour
{
  public GameObject pistola;
  public GameObject pistolaSprite;
  public GameObject espingarda;
  public GameObject espingardaSprite;

 public void TrocarDeArma()
    {
        int arma = Random.Range(0,2);

        pistola.SetActive(arma == 1);
        pistolaSprite.SetActive(arma == 1);
        espingarda.SetActive(arma == 0);
        espingardaSprite.SetActive(arma == 0);
    }
}
