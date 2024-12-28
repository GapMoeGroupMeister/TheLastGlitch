using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource _sfxPlayer;
    public AudioSource _bgmPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfx(AudioClip cilp)
    {
        _sfxPlayer.clip = cilp;
        _sfxPlayer.Play();
    }

    public void PlayBgm(AudioClip cilp)
    {
        _bgmPlayer.clip = cilp;
        _bgmPlayer.Play();
    }

    public void ChangeVoulume(float volume)
    {
        _sfxPlayer.volume = volume / 100;
        _bgmPlayer.volume = volume / 100;
    }
}
