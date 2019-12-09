using UnityEngine;

[CreateAssetMenu(fileName = "New Audio", menuName = "Assets/Audio/AudioClip")]
public class AudioClipData : ScriptableObject
{
    public string Artist;
    public string Title;
    public string Album;

    public Sprite Cover;

    public AudioClip FullTrack;
    public AudioClip Bass;
    public AudioClip Kicks;
    public AudioClip Melody;

    public float[] DropTime;
}