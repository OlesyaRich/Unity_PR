using UnityEngine;

public class CollisionHandler: MonoBehaviour
{
    // Этот метод будет вызываться при столкновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Выводим имя объекта, с которым произошло столкновение
        Debug.Log("Столкновение с объектом: " + collision.gameObject.name);
    }
}