using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FadInOut : MonoBehaviour
{
    public Volume volume;
    private Vignette _vignette;

    private void Awake()
    {
        _vignette = GetComponent<Vignette>();
    }

    public void FadeIn()
    {
        _vignette.intensity = new ClampedFloatParameter(0f, 0f, 1f);
    }

    public void FadeOut()
    {
        _vignette.intensity = new ClampedFloatParameter(0f, 0f, 1f);

    }


}
