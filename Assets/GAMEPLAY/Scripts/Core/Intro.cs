using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace BGCore
{
    public class Intro : MonoBehaviour
    {
        VideoPlayer videoPlayer;
        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.loopPointReached += EndReached;
        }

        void EndReached(VideoPlayer vp)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }

}