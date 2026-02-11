using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    RaycastHit hit;
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = new Ray(transform.position, transform.forward);
          
           if (Physics.Raycast(ray, out hit, 100f))
        {
        Debug.Log("FUNCIONA");
        Debug.Log(hit.transform.name);
        }
        }
       
    }
}
