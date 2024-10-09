using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    public SoundFile soundFile;
    
    public AudioSource BGM;
    public AudioSource SFX;
    public Slider BGMSlider;
    public Slider SFXSlider;


    private void Awake()
    {
        //FindAnyObjectByType<AudioManager>().;



        LoadVolum();
    }





    public void SaveVolum()
    {
        BGM.volume = BGMSlider.value;
        SFX.volume = SFXSlider.value;

        soundFile.sounds.BGM = BGM.volume;
        soundFile.sounds.SFX = SFX.volume;

        soundFile.ProblemSave();
    }

    public void LoadVolum()
    {
        soundFile.ProblemLoad();

        BGM.volume = soundFile.sounds.BGM;
        SFX.volume = soundFile.sounds.SFX;

        BGMSlider.value = BGM.volume;
        SFXSlider.value = SFX.volume;

        

        
    }
}
