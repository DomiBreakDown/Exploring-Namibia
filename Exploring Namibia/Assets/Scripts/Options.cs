using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public float zeroVolume = -80;

    private void Start()
    {
        if(volumeSlider != null && PlayerPrefs.HasKey("volume"))
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void Mute()
    {
        audioMixer.SetFloat("volume", zeroVolume);
        PlayerPrefs.SetFloat("volume", zeroVolume);
        volumeSlider.value = zeroVolume;
    }
}
