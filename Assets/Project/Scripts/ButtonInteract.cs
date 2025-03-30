using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public GameObject trapPrefab; //Префаб ловушки
    public Transform spawnPoint; //Точка спавна ловушки

    private bool activated = false;

    //Метод при нажатии кнопки
    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            Instantiate(trapPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Элемент активирован!");
        }
    }
}