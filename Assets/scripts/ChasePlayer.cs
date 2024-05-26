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

    public AudioSource beaverAudioSource; // Reference to the AudioSource component
    public float maxHearingDistance = 5f; // Maximum distance at which the sound can be heard

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Ensure the AudioSource component is attached
        if (beaverAudioSource == null)
        {
            beaverAudioSource = GetComponent<AudioSource>();
        }

        // Start playing the audio
        beaverAudioSource.Play();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) > agent.stoppingDistance)
        {
            agent.SetDestination(Player.position);
        }

        // Adjust the audio volume based on the distance to the player
        AdjustAudioVolume();
    }

    void AdjustAudioVolume()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        // Adjust the volume based on the distance
        if (distanceToPlayer <= maxHearingDistance)
        {
            float volume = 1 - (distanceToPlayer / maxHearingDistance);
            beaverAudioSource.volume = volume;
        }
        else
        {
            beaverAudioSource.volume = 0;
        }
    }
}