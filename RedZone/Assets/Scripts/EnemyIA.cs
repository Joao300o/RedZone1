using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using NUnit.Framework;

public class EnemyIA : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private NavMeshAgent agent;
    private Transform player;

    [Header("Config")]
    public float distanciaParar = 2f;
    public float velocidadeNormal = 8f;
    public float tempoSlow = 1f;
    public float velocidadeSlow = 4f;

    private bool isChasing = false;
    private bool isSlowed = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent.speed = velocidadeNormal;
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
    public void AplicarSlow()
    { 
        if(!isSlowed)
        StartCoroutine(SlowCoroutine());
    }

    IEnumerator SlowCoroutine()
    {
        isSlowed = true;
        agent.speed = velocidadeSlow;

        yield return new WaitForSeconds(tempoSlow);

        isSlowed = false;
        agent.speed = velocidadeNormal;
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