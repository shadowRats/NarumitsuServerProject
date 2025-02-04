using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    bool done;
    Animator animator;
    
    [SerializeField]
    string s;
    
    TextMesh text;

    private void OnEnable()
    {
        if (text == null)
        {
            animator = GetComponent<Animator>();
            text = GetComponentInChildren<TextMesh>();
        }

        if (animator == null)
        {
            AnimDone();
        }
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

        if (animator != null)
        {
            animator.SetTrigger("close");
        }
        else
        {
            yield return new WaitForSeconds(2);
            AnimDone();
        }
    }
}
