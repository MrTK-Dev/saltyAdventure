using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeCom : MonoBehaviour
{
    public GameObject UI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UI.SetActive(!UI.activeSelf);
        }
    }
}
