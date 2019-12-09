using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class A_MainClass : MonoBehaviour
{
    AudioSource _AudioSource;

    public static float[] _Samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];

    float[] _bufferDecrease = new float[8];

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();

        MakeFrequencyBands();

        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        _AudioSource.GetSpectrumData(_Samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int Count = 0;

        for (int i = 0; i < 8; i++)
        {
            float Average = 0;

            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (sampleCount == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                Average += _Samples[Count] * (Count + 1);
                Count++;
            }

            Average /= Count;

            _freqBand[i] = Average * 1;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if(_freqBand[i] > _bandBuffer[i])
            {
                _bandBuffer[i] = _freqBand[i];

                _bufferDecrease[i] = 0.005f;
            }
            if (_freqBand[i] < _bandBuffer[i])
            {
                _bandBuffer[i] -= _bufferDecrease[i];

                _bufferDecrease[i] *= 1.2f;
            }
        }
    }
}
