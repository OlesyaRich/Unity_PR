using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseSign; 
    public Transform pauseMenu;
    private bool isMenuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isMenuOpen = false)
            {
                OpenMenu();
                isMenuOpen = true;
            }
            else
            {
                CloseMenu();
                isMenuOpen = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MainMenu();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MainMenu();
        }
    }

    public void OpenMenu()
    {
        Debug.Log("1");
        Instantiate(pauseMenu, GameObject.Find("/Canvas").transform);
        Destroy(pauseSign);
    }

    public void CloseMenu()
    {
        Debug.Log("2");
        Destroy(pauseMenu);
        Instantiate(pauseSign, GameObject.Find("/Canvas").transform);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
