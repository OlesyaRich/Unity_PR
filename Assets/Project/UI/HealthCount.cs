using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthCount : MonoBehaviour
{
    public TMP_Text healthText;
    public int currHealth = 10;
    public GameObject player;
    public GameObject textDead;

    void Start()
    {
        healthText.text = $"Health: {currHealth}";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseHealth(1);
        }
    }

    private void LoseHealth(int amount)
    {
        if (currHealth > 0)
        {
            currHealth -= amount; // Уменьшаем здоровье
            healthText.text = $"Health: {currHealth}";
            //Debug.Log($"Health: {currHealth}"); // Выводим текущее здоровье в консоль
        }
        if (currHealth == 0)
        {
            Debug.Log("Player is dead!");
            //Instantiate(textDead, GameObject.Find("/Canvas").transform);
            //SceneManager.LoadScene("MainMenu");
        }
    }
}
