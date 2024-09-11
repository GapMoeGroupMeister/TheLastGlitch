using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfx(AudioClip cilp)
    {
        _audioSource.clip = cilp;
        _audioSource.Play();
    }

    public void ChangeVoulume(float volume)
    {
        _audioSource.volume = volume / 100;
    }
}
