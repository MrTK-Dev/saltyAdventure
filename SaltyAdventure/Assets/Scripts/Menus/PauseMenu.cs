using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!TimeController.GamePaused) {
                PauseGame();
            } else if (TimeController.GamePaused) {
                ResumeGame();
            }
        }
    }

    public void PauseGame() {
        //Pause
        FindObjectOfType<TimeController>().FreezeTime();
        //UI active
        PauseMenuUI.SetActive(true);
    }
    public void ResumeGame() {
        //UnPause
        FindObjectOfType<TimeController>().ResumeTime();
        //UI deactive
        PauseMenuUI.SetActive(false);
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene(sceneBuildIndex:0);
        ResumeGame();
    }
}
