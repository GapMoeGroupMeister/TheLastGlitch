using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxFeedback : Feedback
{
    private AudioSource _sfxSource;
    [SerializeField] private AudioClip CurrentClip;
    private AudioManager _audioManager;

    private void Awake()
    {
        _sfxSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    private void OnEnable()
    {
        if (_audioManager == null)
        {
            AudioManager audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
        }
    }

    public override void PlayFeedback()
    {
        _audioManager.PlaySfx(CurrentClip);
    }

    public override void StopFeedback()
    {
    }
}
