using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class A_MainClass : MonoBehaviour
{
    AudioSource _AudioSource;

    public static float[] _Samples = new float[512];

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        _AudioSource.GetSpectrumData(_Samples, 0, FFTWindow.Blackman);
    }
}
