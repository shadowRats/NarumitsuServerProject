using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{

    protected SpriteRenderer sr;
    protected Animator animator;
    protected Sprite normal;

    [SerializeField]
    protected Sprite[] sprites;

    protected virtual void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        if (normal == null)
        {
            normal = sr.sprite;
        }
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void TalkDone(int id)
    {
        StartCoroutine(Wait(2, id));
    }

    public virtual void AnimDone()
    {
        animator.enabled = false;
    }

    protected virtual void Waited(int id)
    {

    }



    protected void PlayAnim(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    protected void PlayAnim()
    {
        animator.enabled = true;
    }


    protected IEnumerator Wait(float seconds, int id)
    {
        yield return new WaitForSeconds(seconds);
        Waited(id);
    }
}
