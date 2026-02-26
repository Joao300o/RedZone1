using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int danoInimigo;

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerVida pv = col.GetComponent<PlayerVida>();
            if (pv != null)
            {
                pv.ReceberDano(danoInimigo);
            }
        }

    }  
}
