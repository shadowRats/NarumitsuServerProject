using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Talker
{

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
        if (id == 0)
        {
            sr.sprite = sprites[1];
            StartCoroutine(Talk("Dude.........................................................", 1));

        }
        else
        {
            base.Waited(id);
            sr.sprite = normal;
            enabled = false;
        }
    }
}
