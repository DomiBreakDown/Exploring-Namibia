using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private readonly float zeroVolume = 0.001f;
    private static bool muted = false;
    private float lastVol;

    private void Start()
    {
        
        if(volumeSlider != null && PlayerPrefs.HasKey("volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }
        if(PlayerPrefs.HasKey("lastVol"))
        {
            lastVol = PlayerPrefs.GetFloat("lastVol");
        }
            
    }

    public void SetVolume(float volume)
    {
        if(volume > 0.001f)
        {
            muted = false;
        }
        PlayerPrefs.SetFloat("volume", volume);

        volume = Mathf.Log10(volume) * 20;

        audioMixer.SetFloat("volume", volume);
        
    }

    public void Mute()
    {
        
        if(!muted)
        {
            lastVol = volumeSlider.value;
            PlayerPrefs.SetFloat("lastVol", lastVol);
            SetVolume(zeroVolume);
            volumeSlider.value = zeroVolume;
            muted = true;
        }
        else 
        {
            SetVolume(lastVol);
            volumeSlider.value = lastVol;
            muted = false;
        }
    }
}
