using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController6 : MonoBehaviour
{
    public int health = 10;
    public int strength = 20;
    public float speed = 5f;

    public float jumpHeight = 2f; // Высота прыжка
    private float gravity = -9.81f; // Сила тяжести

    private float translationZ = 0f;
    private float translationX = 0f;
    private float translationY = 0f;

    private CharacterController CharacterController;
    private Vector3 velocity; // Вектор скорости (включая прыжок)
    private bool isGrounded; // На земле ли персонаж
    public Transform cameraTransform;

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        if (cameraTransform == null) // Проверка назначения камеры
        {
            cameraTransform = Camera.main != null ? Camera.main.transform : null;
            if (cameraTransform == null) // Проверка назначения камеры
            {
                Debug.LogError("Камера не найдена! Убедитесь, что в сцене есть Main Camera.");
            }
        }
    }

    void Update()
    {
        isGrounded = CharacterController.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = 0f; // Сбрасываем вертикальную скорость, если на земле

        translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(translationX, translationY, translationZ);

        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, speed);


        if (isGrounded && Input.GetButtonDown("Jump")) // Обработка прыжка
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); // Расчет скорости прыжка
            //LoseHealth(1); // Уменьшаем здоровье при прыжке
        }

        velocity.y += gravity * Time.deltaTime; // Применяем гравитацию
        CharacterController.Move((movement + velocity * Time.deltaTime));// Двигаем персонажа

        if (transform.position.y < -10f) //Перезапуск уровня при падении
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.F)) //Взаимодействие с объектами
        {
            Interact();
        }
    }

    private void Interact() //Взаимодействие с кнопками
    {
        RaycastHit hit;
        if (cameraTransform == null)
        {
            Debug.LogError("Камера не назначена! Взаимодействие невозможно.");
            return;
        }

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 3f))
        {
             if (hit.collider.CompareTag("Button"))
            {
                hit.collider.GetComponent<ButtonInteract>().ActivateTrap();
                hit.collider.GetComponent<ButtonDestroy>().ActivateTrap();
            }
            if (hit.collider.CompareTag("Button2"))
            {
                hit.collider.GetComponent<ButtonInteract>().ActivateTrap();
            }
            if (hit.collider.CompareTag("Button3"))
            {
                hit.collider.GetComponent<ButtonDestroy>().ActivateTrap();
            }
        }
    }

    private void LoseHealth(int amount) 
    {
        health -= amount; // Уменьшаем здоровье
        Debug.Log($"Health: {health}"); // Выводим текущее здоровье в консоль

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
