using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    public GameObject trapPrefabDestroy; //Префаб ловушки

    private bool activated = false;

    //Метод при нажатии кнопки
    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            Destroy(trapPrefabDestroy);
            Debug.Log("Элемент уничтожен!");
        }
    }
}
