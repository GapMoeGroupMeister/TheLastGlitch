using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BgmChanger : MonoBehaviour
{
	[SerializeField] private AudioClip _bgmClip;
    private AudioManager _audionManager;

    private void Awake()
    {
        _audionManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();   
    }

    private void Start()
    {
        _audionManager.PlayBgm(_bgmClip);
    }
}
