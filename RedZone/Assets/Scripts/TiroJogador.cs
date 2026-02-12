using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    RaycastHit hit;
    public int dano = 10;
    public int municaoMaxima;
    public int municaoAtual;
    public int municaoTotal;

    public float tempoRecarga = 1.75f;
    bool recarregando = false;



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
