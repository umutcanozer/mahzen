using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    AudioSource _audio;
    void Start()
    {
        _audio = GetComponentInChildren<AudioSource>();
    }

    public void FootR(AnimationEvent animationEvent)
    {
        if(animationEvent.animatorClipInfo.weight > 0.5f)
        {
            _audio.PlayOneShot(_audio.clip);
        }
    }

    public void FootL(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            _audio.PlayOneShot(_audio.clip);
        }
    }
        
}
