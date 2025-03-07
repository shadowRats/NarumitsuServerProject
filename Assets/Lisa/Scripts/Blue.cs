using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{

    readonly List<Collider2D> on = new();

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

        if (on.Count > 0)
        {
            if (Input.GetKeyDown(Controlls.confirm))
            {
                Event e = on[^1].transform.GetComponent<Event>();
                if (e != null && !e.enabled)
                {
                    e.enabled = true;
                }
            }

            if (on[^1].CompareTag("Overlapper"))
            {
                

                if (transform.position.y - transform.lossyScale.y / 2 < on[^1].transform.position.y - on[^1].bounds.size.y / 2)
                {
                    if (transform.position.z >= on[^1].transform.position.z)
                    {
                        transform.position -= Vector3.forward * 0.1f;
                    }
                }
                else
                {
                    if (transform.position.z <= on[^1].transform.position.z)
                    {
                        transform.position += Vector3.forward * 0.1f;
                    }
                }
            }
        }


        if (Input.GetKey(Controlls.down) && !Input.GetKey(Controlls.up))
        {
            last = Controlls.down;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }

            animator.SetInteger("direction", 0);
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
        if (Input.GetKey(Controlls.up) && !Input.GetKey(Controlls.down))
        {
            last = Controlls.up;

            if (!animator.enabled)
            {
                animator.enabled = true;
            }

            animator.SetInteger("direction", 1);
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(Controlls.left) && !Input.GetKey(Controlls.right))
        {
            last = Controlls.left;

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
        if (Input.GetKey(Controlls.right) && !Input.GetKey(Controlls.left))
        {
            last = Controlls.right;

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


        if (animator.enabled && !Input.GetKey(Controlls.right) && !Input.GetKey(Controlls.left) && !Input.GetKey(Controlls.up) && !Input.GetKey(Controlls.down))
        {
            animator.enabled = false;

            if (last == Controlls.right || last == Controlls.left)
            {
                sr.sprite = idles[2];
            }
            if (last == Controlls.up)
            {
                sr.sprite = idles[1];
            }
            if (last == Controlls.down)
            {
                sr.sprite = idles[0];
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        on.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        on.Remove(collision);
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
