using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public void StartGame(string SceneName)
    {
        //StartCoroutine(waiter());
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit game");
    }

    /*IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }*/
}
