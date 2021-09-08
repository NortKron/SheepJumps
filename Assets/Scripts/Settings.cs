using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour 
{

    private bool isFullScreen;

    Resolution[] rsl;
    List<string> resolutions;

    public AudioMixer am;
    public Dropdown dropdown;


    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;

        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}