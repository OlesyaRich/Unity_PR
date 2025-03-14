using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    private float speed = 5f;
    private float translationZ = 0f;
    private float translationX = 0f;
    private float translationY = 0f;
    
    private bool jump;
    private GameObject sphere;
    private CharacterController CharacterController;
    private string Tag;

    void Start()
    {
        //sphere = GameObject.FindGameObjectWithTag("Sphere");
        CharacterController = GetComponent<CharacterController>();
        jump = false;
    }

    void Update()
    {
        //Debug.Log(sphere.GetComponent<RigidBody>().velocity);
        translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(translationX, translationY, translationZ);

        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, speed);
        CharacterController.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb1 = hit.collider.attachedRigidbody;
        if (rb1 != null)
            rb1.linearVelocity = hit.moveDirection * 5f;
    }
}
