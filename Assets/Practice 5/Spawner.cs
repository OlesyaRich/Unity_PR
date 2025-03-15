using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab; //������ �������
    public int numberOfObjects = 50; //���������� ��������
    public float spawnArea = 3f; //������� ������

    public float minSpawnTime = 1f; // ����������� ����� ������
    public float maxSpawnTime = 5f; // ������������ ����� ������
    public float objectLifetime = 5f; // ����� ����� �������

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
            // ���������� ���������� �����
            Renderer objectRenderer = spawnObject.GetComponent<Renderer>(); 
            if (objectRenderer != null)
                objectRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            // ������� ������ ����� �������� �����
            Destroy(spawnObject, objectLifetime);

            // ���� ��������� ����� ����� ��������� ���������� �������
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Update()
    {
        
    }
}
