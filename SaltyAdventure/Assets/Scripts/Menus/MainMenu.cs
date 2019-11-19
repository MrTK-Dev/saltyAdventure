using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenIssueTracker()
    {
        Application.OpenURL("https://github.com/MrTK-Dev/saltyAdventure/issues");
    }

    public void OpenSourceCode()
    {
        Application.OpenURL("https://github.com/MrTK-Dev/saltyAdventure");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
}
