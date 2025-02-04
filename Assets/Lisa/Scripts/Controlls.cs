using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controlls
{
    static readonly KeyCode[][] controlls = new KeyCode[3][] { new KeyCode[6] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Z, KeyCode.X }, new KeyCode[6] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.E, KeyCode.Q }, new KeyCode[6] { KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L, KeyCode.U, KeyCode.O } };

    public static KeyCode up, down, left, right, confirm, back;

    public static void ChangeControlls(int newControlls)
    {
        up = controlls[newControlls][0];
        down = controlls[newControlls][1];
        left = controlls[newControlls][2];
        right = controlls[newControlls][3];
        confirm = controlls[newControlls][4];
        back = controlls[newControlls][5];
    }
}
