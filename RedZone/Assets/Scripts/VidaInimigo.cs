using UnityEngine;
using System.Collections;

public class VidaInimigo : MonoBehaviour
{
    public int vidaInimigo = 100;
    public ArmaJogador armaJogador;

    public EnemyIA enemyIA;

    Color corOriginal;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        corOriginal = rend.material.color;

        enemyIA = GetComponentInChildren<EnemyIA>();
    }
    public void TomarDano(int dano)
    {
        vidaInimigo -= dano;
        StartCoroutine(PiscarDano());

        if (enemyIA != null)
        {
            enemyIA.AplicarSlow();
        }

        if (vidaInimigo <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        armaJogador.TrocarDeArma();
        Destroy(gameObject);
    }

    IEnumerator PiscarDano()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = corOriginal;
    }
}

