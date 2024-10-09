using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxChager : MonoBehaviour
{
	[SerializeField] private AudioClip _sfxCilp;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void SfxChange()
    {
        _audioManager.PlaySfx(_sfxCilp);
    }
}
