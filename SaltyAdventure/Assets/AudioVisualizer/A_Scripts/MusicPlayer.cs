using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject PlayerUI;

    public List<AudioClipData> FullTrackList;

    AudioClipData activeTrack;

    private void Start()
    {
        PlayerUI.SetActive(true);

        SetTrack(FullTrackList[0]);
    }

    void SetTrack(AudioClipData Track)
    {
        activeTrack = Track;

        PlayerUI.GetComponent<MusicPlayerUI>().UpdateTrackUI(Track);
    }

    public void OnClickNext()
    {
        PlayerUI.GetComponent<MusicPlayerUI>().StopAnimations();

        int Index = FullTrackList.IndexOf(activeTrack);

        if (Index != FullTrackList.Count - 1)
            SetTrack(FullTrackList[Index + 1]);

        else
            SetTrack(FullTrackList[0]);
    }

    public void OnClickPrevious()
    {
        PlayerUI.GetComponent<MusicPlayerUI>().StopAnimations();

        int Index = FullTrackList.IndexOf(activeTrack);

        if (Index != 0)
            SetTrack(FullTrackList[Index - 1]);

        else
            SetTrack(FullTrackList[FullTrackList.Count - 1]);
    }
}
