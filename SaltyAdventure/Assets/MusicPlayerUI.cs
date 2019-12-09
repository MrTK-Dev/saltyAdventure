using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayerUI : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject CoverArt;
    public GameObject TitleText;
    public GameObject ArtistText;
    public GameObject AlbumText;
    public GameObject Time;
    public GameObject PauseResume;

    public GameObject Progressbar;
    public GameObject Fill;

    AudioClipData ActiveTrack;

    public void UpdateTrackUI(AudioClipData Track)
    {
        StopCoroutine(AnimateText());

        PlayTrack(Track);

        SetUI();
    }

    void PlayTrack(AudioClipData Track)
    {
        isPaused = false;

        ActiveTrack = Track;
        audioSource.clip = Track.FullTrack;
        audioSource.Play();
    }

    void SetUI()
    {
        CoverArt.GetComponent<Image>().sprite = ActiveTrack.Cover;

        StartCoroutine(CoverFadeIn());
        
        StartCoroutine(AnimateText());

        SetProgressbar();
    }

    IEnumerator CoverFadeIn()
    {
        isFading = true;

        for (int i = 0; i < 255; i++)
        {
            CoverArt.GetComponent<Image>().ChangeAlpha2((i + 1f) / 255f);

            yield return new WaitForSeconds(0.025f);
        }

        isFading = false;
    }

    IEnumerator CoverFadeOut()
    {
        isFading = true;

        for (int i = 0; i < 255; i++)
        {
            CoverArt.GetComponent<Image>().ChangeAlpha2((255f - i) / 255f);

            yield return new WaitForSeconds(0.025f);
        }

        isFading = false;
    }

    IEnumerator AnimateText()
    {
        StartCoroutine(TitleText.GetComponent<TextMeshProUGUI>().TypeWriterEffect(ActiveTrack.Title, 0.1f));

        yield return new WaitForSeconds(2f);

        StartCoroutine(ArtistText.GetComponent<TextMeshProUGUI>().TypeWriterEffect(ActiveTrack.Artist, 0.075f));

        yield return new WaitForSeconds(1f);

        if (ActiveTrack.Album != "")
            StartCoroutine(AlbumText.GetComponent<TextMeshProUGUI>().TypeWriterEffect(ActiveTrack.Album, 0.05f));
        else
            StartCoroutine(AlbumText.GetComponent<TextMeshProUGUI>().TypeWriterEffect(ActiveTrack.Title + " - Single", 0.05f));
    }

    void SetProgressbar()
    {
        Progressbar.GetComponent<Slider>().maxValue = Mathf.Round(ActiveTrack.FullTrack.length);
    }

    public bool isPressed;
    public bool isPaused;
    public bool isFading;

    private void Update()
    {
        if (!isPaused)
        {
            if (!isPressed)
                Progressbar.GetComponent<Slider>().value = audioSource.time;
        }

        if (audioSource.time == ActiveTrack.FullTrack.length)
            GetComponentInParent<MusicPlayer>().OnClickNext();

        if (Progressbar.GetComponent<Slider>().value == Progressbar.GetComponent<Slider>().maxValue - 15)
            StartCoroutine(CoverFadeOut());

        //if (Progressbar.GetComponent<Slider>().value < Progressbar.GetComponent<Slider>().maxValue - 15 && !isFading)
            //CoverArt.GetComponent<Image>().ChangeAlpha2(1f);

        Time.GetComponent<TextMeshProUGUI>().text = TimeFormat(Progressbar.GetComponent<Slider>().value) + " /\n" + TimeFormat(ActiveTrack.FullTrack.length);

        string TimeFormat(float Input)
        {
            string newString = string.Format("{0}:{1:00}", (int)Input / 60, (Input) % 60);

            return newString;
        }

        UpdateColorOfSliderFill();
    }

    void UpdateColorOfSliderFill()
    {
        float Percentage = Progressbar.GetComponent<Slider>().value / Progressbar.GetComponent<Slider>().maxValue;

        Fill.GetComponent<Image>().color = new Color(0, Percentage, 1f);
    }

    public void OnPointerDown()
    {
        isPressed = true;
    }

    public void OnPointerUp()
    {
        audioSource.time = Progressbar.GetComponent<Slider>().value;

        CacheTime = Progressbar.GetComponent<Slider>().value;

        isPressed = false;
    }

    float CacheTime;

    public void OnClickPause()
    {
        isPaused = !isPaused;

        if (audioSource.isPlaying)
        {
            CacheTime = audioSource.time;

            audioSource.Stop();

            PauseResume.GetComponent<A_SwitchButton>().SetPause();
        }

        else
        {
            audioSource.time = CacheTime;

            audioSource.Play();

            PauseResume.GetComponent<A_SwitchButton>().SetResume();
        }
    }

    public void OnClickStop()
    {
        audioSource.Stop();

        ResetTimes();

        PauseResume.GetComponent<A_SwitchButton>().SetPause();

        isPaused = true;
    }

    public void StopAnimations()
    {
        StopAllCoroutines();

        //StopCoroutine("AnimateText");
        TitleText.GetComponent<TextMeshProUGUI>().text = "";
        ArtistText.GetComponent<TextMeshProUGUI>().text = "";
        AlbumText.GetComponent<TextMeshProUGUI>().text = "";

        //StopCoroutine("CoverFadeIn");
        CoverArt.GetComponent<Image>().ChangeAlpha2(0);

        PauseResume.GetComponent<A_SwitchButton>().SetResume();

        ResetTimes();
    }

    void ResetTimes()
    {
        audioSource.time = 0;
        Progressbar.GetComponent<Slider>().value = 0;
        CacheTime = 0;
    }
}
