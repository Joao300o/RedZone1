using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int danoInimigo; // Variavel de dano do Inimigo
    public float tempodeEspera = 2.0f;
    private float proximoTempo = 0f;

    void OnTriggerStay(Collider col) // Indentifica quando o Jogador entra na área do trigger
    {
        if (col.CompareTag("Player") && Time.time >= proximoTempo )
        {
            PlayerVida pv = col.GetComponentInParent<PlayerVida>();

            if (pv != null)
            {
                pv.ReceberDano(danoInimigo);
                proximoTempo = tempodeEspera + Time.time;
            }
        }

    }  
}
