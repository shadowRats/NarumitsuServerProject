using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talker : Event
{
    protected Text text;
    readonly float textSpeed = 0.07f;
    protected override void Awake()
    {
        base.Awake();

        if (text == null)
        {
            text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        }
    }

    protected IEnumerator Talk(string s, int id)
    {

        for (int i = 0; i < s.Length; i++)
        {
            text.text += s[i];
            yield return new WaitForSeconds(textSpeed);
        }

        TalkDone(id);
    }

    protected override void Waited(int id)
    {
        text.text = "";
    }
}
