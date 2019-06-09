using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    public static bool FirstTime = true;
    private int maxVolume = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(FirstTime == true)
        {
            FirstTime = false;
            PlayerPrefs.SetFloat("volume", maxVolume);
            PlayerPrefs.SetInt("minigame1", 0);
        }
    }
}
