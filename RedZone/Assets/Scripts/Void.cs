using UnityEngine;

public class Void : MonoBehaviour
{
    public int damage;
    
    void OnTriggerStay(Collider other)
    {
        other.GetComponent<PlayerVida>().ReceberDano(damage);
    }
}
