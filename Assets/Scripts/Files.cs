using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Files : Menu
{
    [SerializeField]
    GameObject mainMenu;

    protected override void Interact(int current)
    {
        if (current > 0)
        {
            FindObjectOfType<Saver>().Load(current);
        }
        else
        {
            mainMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
