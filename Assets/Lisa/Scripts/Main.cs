using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : Menu
{

    [SerializeField]
    GameObject settingsMenu, filesMenu;
    protected override void Interact(int current)
    {
        if (current == 3)
        {
            Application.Quit();
        }
        else if (current == 2)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (current == 1)
        {
            settingsMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        else if (current == 0)
        {
            filesMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            print("Please make sure the button indicator list matches this script");
        }
    }
}
