using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (isChasing)
        {
            enemy.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isChasing = false;
            enemy.ResetPath();
        }
    }
    public void SetChasing(bool value)
    {
        isChasing = value;

        if (!value)
        {
            enemy.ResetPath();
        }
    }
}