using UnityEngine;

public enum TipoItem
{
    chaveUm,
    municaoArma,
    vida,
    chaveDois
}
public class ColetaItem : MonoBehaviour
{

    public TipoItem tipoItem;

    [Header("Som")]
    public AudioManager audioManager;
    public AudioClip coleta;
    public float volume;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            InventarioJogador iv = col.GetComponentInParent<InventarioJogador>();

            if (iv != null)
            {
                iv.ColetaItem(tipoItem);
                audioManager.TocarSom(coleta, volume);
                Destroy(gameObject);
            }
        }
    }

}