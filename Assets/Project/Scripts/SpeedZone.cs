using UnityEngine;
using UnityEngine.AI;

public class SpeedZone : MonoBehaviour
{
    public float normalSpeed = 10f; // обычная скорость
    public float speedInZone = 1.5f; // скорость в зоне
    private NavMeshAgent agent;

    private void Start()
    {
        // Получаем ссылку на NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed; // Устанавливаем начальную скорость
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("0");
        agent.speed = speedInZone;
        Debug.Log("1");
        // Если агент входит в зону
        if (other.CompareTag("NPC"))
        {
            Debug.Log("2");
            agent.speed = speedInZone; // Устанавливаем замедленную скорость
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("3");
        agent.speed = normalSpeed;
        Debug.Log("4");
        // Если агент покидает зону
        if (other.CompareTag("NPC"))
        {
            Debug.Log("5");
            agent.speed = normalSpeed; // Восстанавливаем обычную скорость
        }
    }
}
