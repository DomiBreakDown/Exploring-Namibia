using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource pickUpAud, 
                deathSoundAud, 
                startEngineAud,
                receiveDamageAud;

    private void Awake()
    {
        pickUpAud = this.transform.GetChild(0).GetComponent<AudioSource>();
        deathSoundAud = this.transform.GetChild(1).GetComponent<AudioSource>();
        startEngineAud = this.transform.GetChild(2).GetComponent<AudioSource>();
        receiveDamageAud = this.transform.GetChild(3).GetComponent<AudioSource>();
    }

    public void PickUpItem()
    {
        pickUpAud.Play(); // https://freesound.org/people/LeMudCrab/sounds/163452/
    }

    public void DeathSound()
    {
        deathSoundAud.Play(); // https://freesound.org/people/rodincoil/sounds/321143/
    }
    
    public void StartEngine()
    {
        startEngineAud.Play(); // https://freesound.org/people/Diramus/sounds/351421/
    }

    public void ReceiveDamage()
    {
        receiveDamageAud.Play(); // https://freesound.org/people/Dirtjm/sounds/262279/
    }

    public void PauseAudio()
    {
        pickUpAud.Pause();
        deathSoundAud.Pause();
        startEngineAud.Pause();
        receiveDamageAud.Pause();
    }

    public void ResumeAudio()
    {
        pickUpAud.UnPause();
        deathSoundAud.UnPause();
        startEngineAud.UnPause();
        receiveDamageAud.UnPause();
    }
}
