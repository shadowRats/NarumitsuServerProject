using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    Saver saver;

    [SerializeField]
    GameObject mainMenu;

    Image[] rows;

    [SerializeField]
    Sprite[] row1, row2, row3;

    Sprite[][] chosen;

    int row, column;

    readonly int[] columns = { 1, 3, 10, 10 };

    string settings;

    protected override void Start()
    {
        base.Start();

        saver = FindObjectOfType<Saver>();

        rows = GetComponentsInChildren<Image>();
        chosen = new Sprite[][] { row1, row2, row3 };


        settings = PlayerPrefs.GetString("settings");

        for (int i = 1; i < 4; i++)
        {
            rows[i].sprite = chosen[i - 1][settings[i - 1] - 48];
        }

    }

    protected override void Update()
    {
        if (Input.GetKeyDown(Controlls.left))
        {
            column--;
            if (column < 0)
            {
                column = columns[row] - 1;
            }

            image.sprite = indicators[GetCurrent()];
        }
        if (Input.GetKeyDown(Controlls.right))
        {
            column++;
            if (column >= columns[row])
            {
                column = 0;
            }

            image.sprite = indicators[GetCurrent()];
        }

        if (Input.GetKeyDown(Controlls.up))
        {
            int prevRow = row;

            row--;

            if (row < 0)
            {
                row = rows.Length - 1;
            }

            NewRow(prevRow);
        }

        if (Input.GetKeyDown(Controlls.down))
        {
            int prevRow = row;

            row++;
            if (row >= rows.Length)
            {
                row = 0;
            }

            NewRow(prevRow);
        }

        if (Input.GetKeyDown(Controlls.confirm))
        {
            if (row > 0)
            {
                rows[row].sprite = chosen[row - 1][column];

                char[] c = settings.ToCharArray();

                c[row - 1] = char.Parse(column + "");

                settings = "";
                foreach(char cc in c)
                {
                    settings += cc;
                }

                PlayerPrefs.SetString("settings", settings);

                if (row == 1)
                {
                    Controlls.ChangeControlls(settings[0] - 48);
                }
                else if (row == 2)
                {
                    saver.UpdateSoundVolume();
                }
                else
                {
                    saver.UpdateMusicVolume();
                }

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
