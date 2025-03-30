using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float desiredDistance = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Вычисляем текущее расстояние до цели
        float currentDistance = Vector3.Distance(transform.position, target.position);

        if (currentDistance < desiredDistance)
        {
            Vector3 direction = (transform.position - target.position).normalized;
            Vector3 newPosition = target.position + direction * desiredDistance;
            agent.SetDestination(newPosition);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }
}
