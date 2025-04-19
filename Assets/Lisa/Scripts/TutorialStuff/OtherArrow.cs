using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherArrow : Talker
{
    readonly string[] lines = { "see i'd tell you to go down diagonally to the right, but i wouldn't really be talking to you then would i?", "maybe i could tell you to go southeast, but i'm assuming you don't have a compass.",  "To be honest, I'm not even sure i'm pointing to the southeast. I don't have a compass either.", "It's just a guess based on someone else's perspective.", "But not even they would be able to know which way their window is turned.", "And what if it doesn't work that way here? What if this world doesn't have that magnetic polarity? What then?..."};

    protected override void OnEnable()
    {
        TalkDone(-1);
    }

    protected override void Waited(int id)
    {
        base.Waited(id);
        id++;

        if (id >= lines.Length)
        {
            animator.enabled = false;
            sr.sprite = normal;
            enabled = false;
        }
        else
        {
            animator.enabled = true;
            StartCoroutine(Talk(lines[id], id));
        }
    }

    protected override void TalkDone(int id)
    {
        base.TalkDone(id);
        animator.enabled = false;
        sr.sprite = sprites[0];
    }
}
