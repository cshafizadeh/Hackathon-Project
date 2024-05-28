using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ChasePlayer : MonoBehaviour
{
    public Transform Player;
    public GameObject Beaver;
    private NavMeshAgent agent;
    public string endScreenSceneName = "GameOver";

    public AudioSource beaverAudioSource; // Reference to the AudioSource component
    public float maxHearingDistance = 5f; // Maximum distance at which the sound can be heard

    private Vector3 lastPosition;
    private float stuckTimeLimit = 2.0f;
    private float stuckTimer = 0.0f;
    private float stuckThreshold = 0.1f;

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

        lastPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) > agent.stoppingDistance)
        {
            agent.SetDestination(Player.position);
        }

        // Adjust the audio volume based on the distance to the player
        AdjustAudioVolume();

        // Check if the beaver is stuck
        CheckIfStuck();
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

    void CheckIfStuck()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        if (distanceMoved <= stuckThreshold)
        {
            stuckTimer += Time.deltaTime;

            if (stuckTimer >= stuckTimeLimit)
            {
                // Handle being stuck: Recalculate path or add jump logic here
                agent.isStopped = true;
                agent.ResetPath();
                agent.SetDestination(Player.position);
                stuckTimer = 0.0f;
                Debug.Log("Beaver was stuck, recalculating path.");
            }
        }
        else
        {
            stuckTimer = 0.0f;
        }

        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(endScreenSceneName);
        }
    }
}
