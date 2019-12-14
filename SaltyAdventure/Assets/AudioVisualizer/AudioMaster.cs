using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMaster : MonoBehaviour
{
    public AudioMixer Mixer;

    public void SetLevel(float Volume)
    {
        Mixer.SetFloat("Master_Level", Volume);
    }
}
