using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private void Start()
    {
        if(volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    //To take the main theme music through all scenes
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
