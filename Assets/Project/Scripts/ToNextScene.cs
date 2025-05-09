using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToNextScene : MonoBehaviour
{
    public string SceneName;
    private bool activated = false;

    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            SceneManager.LoadScene(SceneName);
        }
    }
}