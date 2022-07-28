using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dissonance;
using Dissonance.Config;
using Dissonance.Audio.Capture;
using System;
using UnityEngine.UI;
using TMPro;
public class VoiceChatSetting : MonoBehaviour
{
    public Dropdown audioQualityDropDown;
    public Dropdown noiseSuspensionDropDown;
    public Dropdown voiceDetectionSensitivity;
    public Dropdown echoCancellation;
    public Slider SoundRemovalIntensity;
    public TextMeshProUGUI SoundRemovalIntensityText;



    // Start is called before the first frame update
    void Start()
    {
        voiceSettingOnPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void voiceSettingOnPlay ()
    {
        initialVoiceSetting();
        populateAudioQuality();
        populateNoiseSuspension();
        populatevoiceDetectionSensitivity();
        populateEchoCancellation();
        assignVoiceSetting();
    }

    public void populateAudioQuality ()
    {
        string[] qulaityType = Enum.GetNames(typeof(AudioQuality));
        List<string> name = new List<string>(qulaityType);
        audioQualityDropDown.AddOptions(name);
        
    }

    public void populateNoiseSuspension()
    {
        string[] suppression = Enum.GetNames(typeof(NoiseSuppressionLevels));
        List<string> name = new List<string>(suppression);
        noiseSuspensionDropDown.AddOptions(name);
    }

    public void populatevoiceDetectionSensitivity()
    {
        string[] voiceDetection = Enum.GetNames(typeof(VadSensitivityLevels));
        List<string> name = new List<string>(voiceDetection);
        voiceDetectionSensitivity.AddOptions(name);
    }
    public void populateEchoCancellation()
    {
        string[] mobileEchoCancellation = Enum.GetNames(typeof(AecmRoutingMode));
        List<string> name = new List<string>(mobileEchoCancellation);
        echoCancellation.AddOptions(name);
    }

    public void onVoiceDetectorValueChange()
    {
        if (voiceDetectionSensitivity.value == 0)
        {
            VoiceSettings.Instance.VadSensitivity = VadSensitivityLevels.LowSensitivity;
        }
        else if (voiceDetectionSensitivity.value == 1)
        {
            VoiceSettings.Instance.VadSensitivity = VadSensitivityLevels.MediumSensitivity;
        }
        else if (voiceDetectionSensitivity.value == 2)
        {
            VoiceSettings.Instance.VadSensitivity = VadSensitivityLevels.HighSensitivity;
        }
        else if (voiceDetectionSensitivity.value == 3)
        {
            VoiceSettings.Instance.VadSensitivity = VadSensitivityLevels.VeryHighSensitivity;
        }

        PlayerPrefs.SetInt("voiceDetectionSensitivity", voiceDetectionSensitivity.value);
    }


    public void onNoiseSuspensionValueChange()
    {
        if (noiseSuspensionDropDown.value == 0)
        {
            VoiceSettings.Instance.DenoiseAmount = NoiseSuppressionLevels.Low;
        }
        else if (noiseSuspensionDropDown.value == 1)
        {
            VoiceSettings.Instance.DenoiseAmount = NoiseSuppressionLevels.Moderate;
        }
        else if (noiseSuspensionDropDown.value == 2)
        {
            VoiceSettings.Instance.DenoiseAmount = NoiseSuppressionLevels.High;
        }
        else if (noiseSuspensionDropDown.value == 3)
        {
            VoiceSettings.Instance.DenoiseAmount = NoiseSuppressionLevels.VeryHigh;
        }
        else if (noiseSuspensionDropDown.value == 4)
        {
            VoiceSettings.Instance.DenoiseAmount = NoiseSuppressionLevels.Disabled;
        }

        PlayerPrefs.SetInt("noiseSuspensionDropDown", noiseSuspensionDropDown.value);

    }

    public void onAudioQualityValueChange ()
    {
        if (audioQualityDropDown.value == 0)
        {
            VoiceSettings.Instance.Quality = AudioQuality.Low;
        }else if (audioQualityDropDown.value == 1)
        {
          VoiceSettings.Instance.Quality = AudioQuality.Medium;
        }else if (audioQualityDropDown.value == 2)
        {
            VoiceSettings.Instance.Quality = AudioQuality.High;
        }

        PlayerPrefs.SetInt("audioQualityDropDown", audioQualityDropDown.value);
    }
    public void onEchoCancellationValueChange()
    {
        if (echoCancellation.value == 0)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.QuietEarpieceOrHeadset;
        }
        else if (echoCancellation.value == 1)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.Earpiece;
        }
        else if (echoCancellation.value == 2)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.LoudEarpiece;
        }
        else if (echoCancellation.value == 3)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.Speakerphone;
        }
        else if (echoCancellation.value == 4)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.LoudSpeakerphone;
        }
        else if (echoCancellation.value == 5)
        {
            VoiceSettings.Instance.AecmRoutingMode = AecmRoutingMode.Disabled;
        }

        PlayerPrefs.SetInt("echoCancellation", echoCancellation.value);

    }

    public void changeSoundRemovalIntensity ()
    {
        VoiceSettings.Instance.BackgroundSoundRemovalAmount = SoundRemovalIntensity.value;
        SoundRemovalIntensityText.text = VoiceSettings.Instance.BackgroundSoundRemovalAmount.ToString("0.00");
        PlayerPrefs.SetFloat("SoundRemovalIntensityText", SoundRemovalIntensity.value);
    }

    public void initialVoiceSetting ()
    {
        if (PlayerPrefs.GetInt("VoiceSetting") == 0)
        {
            PlayerPrefs.SetInt("voiceDetectionSensitivity", 0);
            PlayerPrefs.SetInt("noiseSuspensionDropDown", 2);
            PlayerPrefs.SetInt("audioQualityDropDown", 2);
            PlayerPrefs.SetInt("echoCancellation", 3);
            PlayerPrefs.SetFloat("SoundRemovalIntensityText", 0.85f);
            PlayerPrefs.SetInt("VoiceSetting", 1);
        }
    }

    public void resetVoiceSetting()
    {
        PlayerPrefs.SetInt("VoiceSetting", 0);

        if (PlayerPrefs.GetInt("VoiceSetting") == 0)
        {
            PlayerPrefs.SetInt("voiceDetectionSensitivity", 0);
            PlayerPrefs.SetInt("noiseSuspensionDropDown", 2);
            PlayerPrefs.SetInt("audioQualityDropDown", 2);
            PlayerPrefs.SetInt("echoCancellation", 3);
            PlayerPrefs.SetFloat("SoundRemovalIntensityText", 0.85f);
            PlayerPrefs.SetInt("VoiceSetting", 1);
            populateAudioQuality();
            populateNoiseSuspension();
            populatevoiceDetectionSensitivity();
            populateEchoCancellation();
            assignVoiceSetting();
        }
    }

    public void assignVoiceSetting ()
    {
        voiceDetectionSensitivity.value = PlayerPrefs.GetInt("voiceDetectionSensitivity");
        noiseSuspensionDropDown.value = PlayerPrefs.GetInt("noiseSuspensionDropDown");
        audioQualityDropDown.value = PlayerPrefs.GetInt("audioQualityDropDown");
        echoCancellation.value = PlayerPrefs.GetInt("echoCancellation");
        SoundRemovalIntensity.value = PlayerPrefs.GetFloat("SoundRemovalIntensityText");
        SoundRemovalIntensityText.text = SoundRemovalIntensity.value.ToString("0.00");
    }
}
