using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutBird : Talker
{
    protected override void OnEnable()
    {
        base.OnEnable();
        animator.enabled = false;
        sr.sprite = sprites[0];
        StartCoroutine(Wait(1, 0));
    }

    protected override void Waited(int id)
    {
        base.Waited(id);
        if (id == 0)
        {
            StartCoroutine(Talk("Congratulations", 1));
        }
        else if (id == 1)
        {
            StartCoroutine(Talk("You followed some simple instructions and completed the tutorial", 2));
        }
        else if (id == 2)
        {
            StartCoroutine(Talk("poof", 3));
        }
        else if (id == 3)
        {
            SceneManager.LoadScene("Main");
        }
    }


}
