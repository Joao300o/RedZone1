using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    int vidaAtual;
    int vidaMax = 100;

    int danoSofrido;

    [SerializeField] private BarraDeVida barraDeVida;

    void Start()
    {
        vidaAtual = vidaMax;

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);
    }

    public void ReceberDano(int danoJogador)
    {
        vidaAtual -= danoJogador;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);
    }

    public void Curar(int curar)
    {
        vidaAtual += curar;
        if (vidaAtual > vidaMax)
            vidaAtual = vidaMax;

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);

    }
}
