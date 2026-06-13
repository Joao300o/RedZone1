using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image barraDeVidaImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlterarBarraDeVida(int vidaAtual, int vidaMax)
    {
        barraDeVidaImage.fillAmount = (float) vidaAtual / vidaMax;
    }
}
