using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    protected Sprite[] indicators;

    protected Image image;

    int current;

    protected virtual void Start()
    {
        image = GetComponent<Image>();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            current--;
            if (current < 0)
            {
                current = indicators.Length - 1;
            }

            image.sprite = indicators[current];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            current++;
            if (current >= indicators.Length)
            {
                current = 0;
            }

            image.sprite = indicators[current];
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact(current);
        }
    }

    protected virtual void Interact(int current)
    {

    }
}
