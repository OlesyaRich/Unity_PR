using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseSign;
    public GameObject pauseMenu;

    public void OpenMenu()
    {
        Debug.Log("1");
        Instantiate(pauseMenu, GameObject.Find("/Canvas").transform);
        Destroy(pauseSign);
    }

    public void CloseMenu()
    {
        Destroy(pauseMenu);
        Instantiate(pauseSign, GameObject.Find("/Canvas").transform);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
