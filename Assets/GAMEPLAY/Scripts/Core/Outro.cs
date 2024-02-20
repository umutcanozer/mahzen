using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace BGCore
{
    public class Outro : MonoBehaviour
    {
        VideoPlayer videoPlayer;
        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.loopPointReached += EndReached;
        }

        void EndReached(VideoPlayer vp)
        {
            SceneManager.LoadScene(1);
        }

    }

}
