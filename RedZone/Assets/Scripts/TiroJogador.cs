using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    RaycastHit hit;
    public int dano = 10;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = new Ray(transform.position, transform.forward);
          
           if (Physics.Raycast(ray, out hit, 100f))
        {
        Debug.Log(hit.transform.name);

        VidaInimigo inimigo = hit.transform.GetComponent<VidaInimigo>();
        
        if (inimigo != null)
                {
                    inimigo.TomarDano(dano);
                }
        }
        }
       
    }
}
