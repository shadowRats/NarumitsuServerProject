using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Event
{
    AudioSource a;

    protected override void Awake()
    {
        a = GetComponent<AudioSource>();
    }

    protected override void OnEnable()
    {
        a.Play();
        enabled = false;
    }
}
