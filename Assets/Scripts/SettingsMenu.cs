using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField]
    GameObject mainMenu;

    Image[] rows;

    [SerializeField]
    Sprite[] row1, row2, row3;

    Sprite[][] chosen;

    int row, column;

    readonly int[] columns = { 1, 3, 10, 10 };

    protected override void Start()
    {
        base.Start();

        rows = GetComponentsInChildren<Image>();
        chosen = new Sprite[][] { row1, row2, row3 };
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            column--;
            if (column < 0)
            {
                column = columns[row] - 1;
            }

            image.sprite = indicators[GetCurrent()];
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            column++;
            if (column >= columns[row])
            {
                column = 0;
            }

            image.sprite = indicators[GetCurrent()];
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int prevRow = row;

            row--;

            if (row < 0)
            {
                row = rows.Length - 1;
            }

            NewRow(prevRow);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int prevRow = row;

            row++;
            if (row >= rows.Length)
            {
                row = 0;
            }

            NewRow(prevRow);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (row > 0)
            {
                rows[row].sprite = chosen[row - 1][column];
            }
            else
            {
                mainMenu.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    void NewRow(int prevRow)
    {
        if (row == 0)
        {
            column = 0;
        }
        else if (row == 1)
        {
            column /= 4;
        }
        else if (prevRow != 2 && prevRow != 3)
        {
            column *= 4;
        }

        image.sprite = indicators[GetCurrent()];
    }

    int GetCurrent()
    {
        int forward = 0;

        for (int i = 0; i < row; i++)
        {
            forward += columns[i];
        }

        return forward + column;
    }

    protected override void Interact(int current)
    {
        mainMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

}
