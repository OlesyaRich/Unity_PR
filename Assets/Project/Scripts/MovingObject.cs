using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 3.0f;
    public float distance = 5.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float delta = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = startPosition + new Vector3(0,0,delta);
    }
}
