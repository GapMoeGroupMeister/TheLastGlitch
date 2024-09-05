using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxFeedback : Feedback
{
    private AudioSource _sfxSource;

    private void Awake()
    {
        _sfxSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _sfxSource.clip = _sfxSource.clip;
    }

    public override void PlayFeedback()
    {
        _sfxSource.Play();
    }

    public override void StopFeedback()
    {
    }
   
}
