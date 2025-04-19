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
    AudioSource music;
    AudioSource[] sound;
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        SceneLoaded();

        if (!PlayerPrefs.HasKey("settings"))
        {
            PlayerPrefs.SetString("settings", "055");
        }

        Controlls.ChangeControlls(PlayerPrefs.GetString("settings")[0] - 48);

        music = GetComponent<AudioSource>();
        UpdateMusicVolume();


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

    public void LoadFile(int file)
    {
        current = file;

        if (!PlayerPrefs.HasKey("file" + file))
        {
            PlayerPrefs.SetString("file" + file, "0");
        }

        LoadScene("Scene" + PlayerPrefs.GetString("file" + file)[0]);
        music.Play();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);

        if (scene == "Main")
        {
            Destroy(gameObject);
        }
    }

    public void SceneLoaded()
    {
        sound = FindObjectsOfType<AudioSource>();

        UpdateSoundVolume();
    }

    public void UpdateSoundVolume()
    {
        float volume = (PlayerPrefs.GetString("settings")[1] - 48) / 10f;

        foreach (AudioSource a in sound)
        {
            if (a != music)
            {
                a.volume = volume;
            }
        }
    }
    public void UpdateMusicVolume()
    {
        music.volume = (PlayerPrefs.GetString("settings")[2] - 48) / 10f;
    }
}
