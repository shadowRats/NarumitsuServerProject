using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    int current;

    [SerializeField]
    GameObject filesParent;
    Text[] files;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        files = filesParent.GetComponentsInChildren<Text>();

        for (int i = 0; i < files.Length; i++)
        {
            if (PlayerPrefs.HasKey("file" + (i + 1)))
            {
                files[i].text = "Load File " + (i + 1) + ": " + PlayerPrefs.GetString("file" + (i + 1));
            }
            else
            {
                files[i].text = "Start File " + (i + 1);
            }
        }
    }

    public void Load(int file)
    {
        DontDestroyOnLoad(gameObject);

        current = file;

        if (!PlayerPrefs.HasKey("file" + file))
        {
            PlayerPrefs.SetString("file" + file, "0");
        }

        SceneManager.LoadScene("Scene" + PlayerPrefs.GetString("file" + file)[0]);
    }
}
