using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent inimigo;
    private Transform Player;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        inimigo.SetDestination(Player.position);
    }
}
