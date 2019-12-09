using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ToolTip;
    public GameObject SelectedButton;

    public void SelectButton(GameObject Button)
    {
        if (SelectedButton == Button)
        {
            StopAllCoroutines();  //stop animation

            ToolTip.transform.SetSiblingIndex(0);   //Sibling Order -> background

            gameObject.GetComponent<ButtonHover>().Selected = false;    //bool for Hover Check

            SelectedButton = null;  //clear SelectedButton

            ToolTip.GetComponent<MenuToolTip>().ClearToolTip();   //clear ToolTip

            gameObject.GetComponent<ButtonHover>().EnableButtons();   //enable MiddleButtons
        }
        else
        {
            ToolTip.transform.SetSiblingIndex(1);   //Sibling Order -> foreground

            gameObject.GetComponent<ButtonHover>().Selected = true; //bool for Hover Check

            SelectedButton = Button;    //set SelectedButton

            gameObject.GetComponent<ButtonHover>().SwitchButtons(Button);   //disable MiddleButtons

            ToolTip.GetComponent<MenuToolTip>().ToggleToolTip(Button);  //activate ToolTip

            ToolTip.GetComponent<MenuToolTip>().Description.text = "";  //clear Description

            if (Button.name == "Continue")
            {
                ToolTip.GetComponent<MenuToolTip>().ShowContinue(Button);
            }
            else if (Button.name == "Quit")
            {
                ToolTip.GetComponent<MenuToolTip>().ShowQuit(Button);
            }
        }
    }

    public void OnPointerExit() //same effect as pressing the same button
    {
        SelectButton(SelectedButton);
    }

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
        UnityEditor.EditorApplication.isPlaying = false;

        //change for builds
        //Application.Quit();
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(sceneBuildIndex:1);

        //gameObject.GetComponent<PlayerData>().WriteToJSON();

        //gameObject.GetComponent<PlayerInfo>().TestJsonReader();

        
    }

    //Json Tester
    public void Save()
    {
        SaveFunctions.Save();
    }

    public void Load()
    {
        Debug.Log(LoadPlayerData.Read("PlayerData").Place);
    }
}