using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    GameObject on;

    Animator animator;
    SpriteRenderer sr;

    [SerializeField]
    Sprite[] idles;

    readonly float speed = 2;
    KeyCode last;


    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        idles[0] = sr.sprite;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && on != null)
        {
            on.transform.GetChild(0).gameObject.SetActive(true);
        }


        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            last = KeyCode.DownArrow;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }

            animator.SetInteger("direction", 0);
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            last = KeyCode.UpArrow;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }

            animator.SetInteger("direction", 1);
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            last = KeyCode.LeftArrow;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }
            if (sr.flipX)
            {
                sr.flipX = false;
            }

            animator.SetInteger("direction", 2);
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            last = KeyCode.RightArrow;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }
            if (!sr.flipX)
            {
                sr.flipX = true;
            }

            animator.SetInteger("direction", 2);
            transform.position += speed * Time.deltaTime * Vector3.right;
        }


        if (animator.enabled && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            animator.enabled = false;

            if (last == KeyCode.RightArrow || last == KeyCode.LeftArrow)
            {
                sr.sprite = idles[2];
            }
            if (last == KeyCode.UpArrow)
            {
                sr.sprite = idles[1];
            }
            if (last == KeyCode.DownArrow)
            {
                sr.sprite = idles[0];
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        on = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (on == collision.gameObject)
        {
            on = null;
        }
    }

    private void OnDisable()
    {
        if (animator.enabled)
        {
            animator.enabled = false;
        }

        sr.sprite = idles[0];
    }
}
