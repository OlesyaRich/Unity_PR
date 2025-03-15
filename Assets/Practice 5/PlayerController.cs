using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int health = 10;
    public int strength = 20;
    public float speed = 5f;

    public float jumpHeight = 2f; // ������ ������
    private float gravity = -9.81f; // ���� �������

    private float translationZ = 0f;
    private float translationX = 0f;
    private float translationY = 0f;

    private CharacterController CharacterController;
    private Vector3 velocity; // ������ �������� (������� ������)
    private bool isGrounded; // �� ����� �� ��������

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = CharacterController.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = 0f; // ���������� ������������ ��������, ���� �� �����

        translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(translationX, translationY, translationZ);

        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (health > 0)
        {
            if (isGrounded && Input.GetButtonDown("Jump")) // ��������� ������
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); // ������ �������� ������
                LoseHealth(1); // ��������� �������� ��� ������
            }

            velocity.y += gravity * Time.deltaTime; // ��������� ����������
            CharacterController.Move((movement + velocity * Time.deltaTime));// ������� ���������
        }
        else CharacterController.Move(movement);
    }

    private void LoseHealth(int amount) 
    {
        health -= amount; // ��������� ��������
        Debug.Log($"Health: {health}"); // ������� ������� �������� � �������

        if (health <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb1 = hit.collider.attachedRigidbody;
        if (rb1 != null)
            rb1.linearVelocity = hit.moveDirection * 5f;
    }
}
