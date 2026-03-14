using UnityEngine;

public enum TipoItem
{
   chaveUm,
   vida,
   chaveDois
}
public class ColetaItem : MonoBehaviour
{
 
    public TipoItem tipoItem;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            InventarioJogador iv = col.GetComponentInParent<InventarioJogador>();

         if(iv != null)
         {
            iv.ColetaItem(tipoItem);
            Destroy(gameObject);
          }
        }
    }

}