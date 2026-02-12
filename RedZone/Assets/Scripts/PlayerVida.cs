using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
public Slider vida;
    void Start()
    {
        vida.value = 100f;
    }

    void Update()
    {
        if(vida.value <= 0)
        {
            Destroy(gameObject);
        }
    }   
    
     public void ReceberDano(int danoJogador)
    {
        vida.value -= danoJogador * Time.deltaTime;
    }
}
