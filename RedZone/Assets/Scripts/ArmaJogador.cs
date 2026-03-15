using UnityEngine;

public class ArmaJogador : MonoBehaviour
{
  public GameObject pistola;
  public GameObject espingarda;

 public void TrocarDeArma()
    {
        int arma = Random.Range(0,2);

        pistola.SetActive(arma == 1);
        espingarda.SetActive(arma == 0);
    }
}
