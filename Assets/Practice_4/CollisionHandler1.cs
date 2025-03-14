using UnityEngine;

public class CollisionHandler1: MonoBehaviour
{
    private string Tag;
    // Этот метод будет вызываться при столкновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Выводим имя объекта, с которым произошло столкновение
        Tag = collision.gameObject.tag;
        Debug.Log("Произошло столкновение с: " + "\nTag = " + Tag + "; Name: " + GameObject.FindWithTag(Tag).name);
    }
}