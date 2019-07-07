using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoPlayer;
    private bool isPlaying = false;

    private void Start()
    {
        videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    private void Update()
    {
        if(videoPlayer.isPlaying)
        {
            isPlaying = true;
        }
        if(!videoPlayer.isPlaying && isPlaying)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
