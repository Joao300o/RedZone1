using UnityEngine;

public class ZonaDeteccao : MonoBehaviour
{
    public EnemyIA enemy;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.SetChasing(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.SetChasing(false);
        }
    }
}