using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private InputAction moveAction;

    private void OnEnable()
    {
        // Создаем действие вручную
        // Создаем действие с композитным биндингом (WASD + стрелки)
        moveAction = new InputAction("Move", InputActionType.Value);

        // Добавляем 2D композитный ввод (аналог Input.GetAxis)
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        if (!IsOwner) return;
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
    }
}