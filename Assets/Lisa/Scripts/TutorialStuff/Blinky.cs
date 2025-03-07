using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : Event
{

    protected override void OnEnable()
    {
        base.OnEnable();
        PlayAnim();
    }

    public override void AnimDone()
    {
        base.AnimDone();
        sr.sprite = normal;
        enabled = false;
    }

}
