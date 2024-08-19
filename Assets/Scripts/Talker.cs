using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    bool done;
    Animator animator;
    string s = "Dude just Go down";
    
    TextMesh text;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<TextMesh>();
    }

    public void AnimDone()
    {
        if (done)
        {
            done = false;
            text.text = "";
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(Talk());
        }
    }

    IEnumerator Talk()
    {
        for (int i = 0; i < s.Length; i++)
        {
            text.text += s[i];
            yield return new WaitForSeconds(0.2f);
        }

        done = true;
        animator.SetTrigger("close");
    }
}
