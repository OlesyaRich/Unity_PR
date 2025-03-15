using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab; //Префаб объекта
    public int numberOfObjects = 50; //Количество объектов
    public float spawnArea = 3f; //Область спавна

    public float minSpawnTime = 1f; // Минимальное время спавна
    public float maxSpawnTime = 5f; // Максимальное время спавна
    public float objectLifetime = 5f; // Время жизни объекта

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnArea, spawnArea),
                5,
                Random.Range(-spawnArea, spawnArea)
            );

            GameObject spawnObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            // Присвоение случайного цвета
            Renderer objectRenderer = spawnObject.GetComponent<Renderer>(); 
            if (objectRenderer != null)
                objectRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            // Удаляем объект через заданное время
            Destroy(spawnObject, objectLifetime);

            // Ждем случайное время перед созданием следующего объекта
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Update()
    {
        
    }
}
