using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
