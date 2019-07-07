using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroController : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoPlayer;
    private bool isPlaying = false;

    private void Start()
    {
        videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Outro.mp4");
    }

    private void Update()
    {
        if (videoPlayer.isPlaying)
        {
            isPlaying = true;
        }
        if (!videoPlayer.isPlaying && isPlaying)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
