using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talker : Event
{
    protected Text text;
    readonly float textSpeed = 0.07f;
    AudioSource a;
    
    [SerializeField]
    AudioClip[] notes;

    protected override void Awake()
    {
        base.Awake();

        a = GetComponent<AudioSource>();
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    protected IEnumerator Talk(string s, int id)
    {

        for (int i = 0; i < s.Length; i++)
        {
            text.text += s[i];

            if (i % 3 == 0)
            {
                a.clip = notes[Random.Range(0, notes.Length - 1)];
                a.Play();
            }

            yield return new WaitForSeconds(textSpeed);
        }

        a.Stop();
        TalkDone(id);
    }

    protected override void Waited(int id)
    {
        text.text = "";
    }
    protected virtual void TalkDone(int id)
    {
        StartCoroutine(Wait(2, id));
    }
}
