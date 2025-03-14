using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private Transform lookPosition;
    private Vector3 offset;
    private float deltaY;
    private float sensitivity = 3f;

    void Start()
    {
        offset = Target.transform.position - transform.position;
    }

    void Update()
    {
        deltaY += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion rotation = Quaternion.Euler(0, deltaY, 0);
        transform.position = Target.transform.position - (rotation * offset);
        transform.LookAt(lookPosition.position);
    }
}
