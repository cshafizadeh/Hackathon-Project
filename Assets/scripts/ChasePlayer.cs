using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChasePlayer : MonoBehaviour
{

    public Transform Player;
    public GameObject Beaver;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) > agent.stoppingDistance)
        {
            agent.SetDestination(Player.position);
        }
    }
}