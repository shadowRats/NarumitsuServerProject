using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Talker
{
    string[] lines = { "Dude.........................................................", "I'm an arrow", "just go to where i'm pointing" };

    protected override void OnEnable()
    {
        base.OnEnable();
        sr.sprite = sprites[0];
        StartCoroutine(Wait(1, 0));
    }

    protected override void TalkDone(int id)
    {
        base.TalkDone(id);
        sr.sprite = sprites[0];
    }

    protected override void Waited(int id)
    {
        base.Waited(id);
        if (id < lines.Length)
        {
            id++;
            sr.sprite = sprites[1];
            StartCoroutine(Talk(lines[id - 1], id));

        }
        else
        {
            sr.sprite = normal;
            enabled = false;
        }
    }
}
