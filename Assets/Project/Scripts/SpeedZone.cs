using UnityEngine;
using UnityEngine.AI;

public class SpeedZone : MonoBehaviour
{
    private float normalSpeed; // обычная скорость
    public float speedInZone = 1.5f; // скорость в зоне
    private NavMeshAgent agent;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Player"))
        {
            agent = other.gameObject.GetComponent<NavMeshAgent>();
            normalSpeed = agent.speed;
            agent.speed = speedInZone;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("Player"))
        {
            agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.speed = normalSpeed;
        }
    }
}
