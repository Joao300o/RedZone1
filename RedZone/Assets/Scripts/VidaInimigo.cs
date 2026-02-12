using UnityEngine;
using System.Collections;

public class VidaInimigo : MonoBehaviour
{
public int vidaInimigo = 100;

Color corOriginal;
Renderer rend;

void Start()
    {
        rend = GetComponent<Renderer>();
        corOriginal = rend.material.color;
    }
 public void TomarDano(int dano)
    {
        vidaInimigo -= dano;

        if (vidaInimigo <= 0)
        {
            Morrer();
            StartCoroutine(PiscarDano());
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }

    IEnumerator PiscarDano()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = corOriginal;
    }
}

