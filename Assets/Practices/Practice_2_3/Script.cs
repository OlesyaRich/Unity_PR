using UnityEngine;

public class Script: MonoBehaviour
{
    public float RandomNumber = 7;
    public GameObject SomeObject;

    void Start() { }

    void Update()
    {
        Randomizer();
    }

    void Randomizer()
    {
        RandomNumber = Random.Range(1, 10);
        Debug.Log(RandomNumber);

        if (RandomNumber == 3)
        {
            Debug.Log("Проверка условия");

        }
    }
}
