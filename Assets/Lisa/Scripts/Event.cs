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
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
    }

    protected virtual void OnEnable()
    {

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
