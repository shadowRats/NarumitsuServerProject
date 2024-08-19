using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Animator animator;
    Image image;

    [SerializeField]
    Sprite tut2;

    Sprite empty;

    [SerializeField]
    Transform cam;

    [SerializeField]
    Blue blue;

    readonly float camSpeed = 3, textSpeed = 0.5f;

    int step;

    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        enabled = false;
        empty = image.sprite;
    }

    void Update()
    {

        if (step == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Moved();
            }
        }
        else if (step == 1)
        {
            if (Mathf.Abs(blue.transform.position.x - cam.position.x) > 4 || Mathf.Abs(blue.transform.position.y - cam.position.y) > 3)
            {
                blue.enabled = false;
                StartCoroutine(MoveCam());
                step++;
            }
        }
        else if (step == 3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                step++;
                image.sprite = empty;
                transform.GetChild(3).gameObject.SetActive(false);
            }
        }


    }

    public void AnimDone(int anim)
    {
        animator.enabled = false;

        if (anim == 1)
        {
            enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                Moved();
            }
        }
    }
    
    void Moved()
    {
        blue.enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        image.color = Color.white - Color.black;
        image.sprite = tut2;
        step++;
    }

    IEnumerator MoveCam()
    {
        Vector3 v = new Vector3(blue.transform.position.x, blue.transform.position.y, 0) - new Vector3(cam.position.x, cam.position.y, 0);
        
        while (v.magnitude > camSpeed * Time.deltaTime)
        {
            cam.position += camSpeed * Time.deltaTime * v.normalized;
            v = new Vector3(blue.transform.position.x, blue.transform.position.y, 0) - new Vector3(cam.position.x, cam.position.y, 0);
            yield return null;
        }

        cam.position = blue.transform.position + Vector3.back * 10;
        cam.parent = blue.transform;

        StartCoroutine(ShowTut2());
    }

    IEnumerator ShowTut2()
    {
        while (image.color.a < 1 - textSpeed * Time.deltaTime)
        {
            Color c = image.color + Color.black * textSpeed * Time.deltaTime;
            image.color = c;
            yield return null;

        }

        image.color = Color.white;
        transform.GetChild(3).gameObject.SetActive(true);
        blue.enabled = true;
        step++;

    }
}