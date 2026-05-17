using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private NavMeshAgent agent;
    private Transform player;

    [Header("Config")]
    public float distanciaParar = 2f;

    private bool isChasing = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;

        if (isChasing)
        {
            float distancia = Vector3.Distance(transform.position, player.position);

            if (distancia > distanciaParar)
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }
            else
            {
                PararInimigo();
            }
        }
    }

    public void SetChasing(bool value)
    {
        isChasing = value;

        if (!value)
        {
            PararInimigo();
        }
    }

    void PararInimigo()
    {
        agent.isStopped = true;
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }
}