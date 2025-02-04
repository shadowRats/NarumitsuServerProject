using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNothing : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(FindObjectOfType<Saver>().gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}
