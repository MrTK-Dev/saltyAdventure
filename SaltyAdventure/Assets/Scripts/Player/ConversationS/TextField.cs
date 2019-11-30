using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextField : MonoBehaviour
{
    #region Singleton

    public static TextField instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject UI;
    public Text TText;
    public Text ForwardText;

    public float Delay = 0.05f;
    public float PuncDelay = 0.1f;

    //test
    string[] TestString = new string[] {"tes.tsssssssssssssssssssssssssss....0", "lo.......................l1"};
    bool animator;

    string[] FullText;
    int CurrentText = 0;
    bool Skipable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))    //Test
        {
            TriggerTextfield(TestString);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Skipable)
        {
            if (CurrentText < FullText.Length - 1)
            {
                SkipText();

                Skipable = false;
                ToggleImg();
            }
            else
            {
                ClearTextfield();
            }
        }


        BadAnimation();
    }

    public void TriggerTextfield(string[] newString)
    {
        FullText = newString;

        UI.SetActive(true);

        StartCoroutine(AnimateText());
    }

    void ClearTextfield()
    {
        UI.SetActive(false);    //disable UI

        PlayerStateManager.instance.setState(PlayerStateManager.PlayerState.Idle);  //player state

        CurrentText = 0;    //reset Index
    }

    void SkipText()
    {
        StopAllCoroutines();
        CurrentText++;
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < (FullText[CurrentText].Length + 1); i++)
        {
            TText.text = FullText[CurrentText].Substring(0, i);

            if (FullText[CurrentText].Substring(0, i).EndsWith("."))  //Delay
            {
                yield return new WaitForSeconds(PuncDelay);
            }
            else
            {
                yield return new WaitForSeconds(Delay);
            }
        }

        //Makes it Skipable
        Skipable = true;

        //add Image
        ToggleImg();

        Debug.Log("Finished Entry number " + (CurrentText + 1));
    }

    void ToggleImg()
    {
        ForwardText.gameObject.SetActive(!ForwardText.gameObject.activeSelf);
    }

    //ToDo
    //make this more efficient

    void BadAnimation()
    {
        if (ForwardText.gameObject.activeSelf && !animator)
        {
            Invoke("BadAnimation2", 1f);
            animator = true;
        }
    }

    void BadAnimation2()
    {
        if (ForwardText.text == "")
        {
            ForwardText.text = "<";
        }
        else
        {
            ForwardText.text = "";
        }

        animator = false;
    }
}
