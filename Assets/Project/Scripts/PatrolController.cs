using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{
    public Transform[] waypoints;
    private NavMeshAgent agent;
    private int currentWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 0;
        SetNextPoint();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f)
            SetNextPoint();
    }

    void SetNextPoint()
    {
        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}
