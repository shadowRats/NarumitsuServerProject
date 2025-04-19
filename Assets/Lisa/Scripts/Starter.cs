using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Saver>().SceneLoaded();
        //Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<Saver>().LoadScene("Main");
        }
    }
}
