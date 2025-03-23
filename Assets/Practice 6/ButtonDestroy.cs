using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    public GameObject trapPrefabInstantiate; //Префаб ловушки
    public GameObject trapPrefabDestroy; //Префаб ловушки
    public Transform spawnPoint; //Точка спавна ловушки

    private bool activated = false;

    //Метод при нажатии кнопки
    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            Destroy(trapPrefabDestroy);
            Debug.Log("Стена снесена!");
            Instantiate(trapPrefabInstantiate, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Кнопка активирована!");
        }
    }
}
