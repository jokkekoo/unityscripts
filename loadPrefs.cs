using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class loadPrefs : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private mainMenu menuController;

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeSliderValue = null;
    [SerializeField] private Slider audioSlider = null;

    [Header("Brightness Setting")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle fullScreenToggle;

    private void Awake()
    {
        if (canUse)
        {
            if(PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeSliderValue.text = localVolume.ToString("0.0");
                audioSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetButton("Audio");
            }
        }

        if(PlayerPrefs.HasKey("masterFullscreen"))
        {
            int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

            if(localFullscreen == 1)
            {
                Screen.fullScreen = true;
                fullScreenToggle.isOn = true;
            }
            else
            {
                Screen.fullScreen = false;
                fullScreenToggle.isOn = false;
            }
        }

        if(PlayerPrefs.HasKey("masterBrightness"))
        {
            float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

            brightnessTextValue.text = localBrightness.ToString("0.0");
            brightnessSlider.value = localBrightness;
        }
    }
}
