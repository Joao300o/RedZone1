using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int danoInimigo; // Variavel de dano do Inimigo
    public float tempodeEspera = 2.0f;
    private float proximoTempo = 0f;

    public AudioManager audioManager;
    public AudioClip somHit;

    void OnTriggerStay(Collider col) // Indentifica quando o Jogador entra na área do trigger
    {
        if (col.CompareTag("Player") && Time.time >= proximoTempo )
        {
            PlayerVida pv = col.GetComponentInParent<PlayerVida>();

            if (pv != null)
            {
                pv.ReceberDano(danoInimigo);
                audioManager.TocarSom(somHit, 0.7f);
                proximoTempo = tempodeEspera + Time.time;
            }
        }

    }  
}
