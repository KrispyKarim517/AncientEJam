using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    Dependencies: script_AudioManager, script_OptionsMenuButtons
    
    A script that controls the volume slider
*/
public class script_AudioSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMProUGUI_VolumeTitle = null;
    [SerializeField] private Slider slider_VolumeSlider = null;
    [SerializeField] private script_OptionsMenuButtons ref_OptionsMenuButtons = null;
    private script_AudioManager ref_AudioManager = null;
    private string string_VolumeTitleDefault = "VOLUME: ";
    
    private void Awake()
    {
        GameObject gobj_temp_AudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        ref_AudioManager = gobj_temp_AudioManager.GetComponent<script_AudioManager>();
        slider_VolumeSlider.value = ref_AudioManager.maxVolume;
    }
    
    public void SetVolume()
    {
        ref_AudioManager.maxVolume = slider_VolumeSlider.value;
        UpdateText();
        ref_OptionsMenuButtons.ActivateDefaultButton();
    }
    
    public void ResetVolume()
    {
        ref_AudioManager.maxVolume = 1f;
        slider_VolumeSlider.value = ref_AudioManager.maxVolume;
        UpdateText();
        ref_OptionsMenuButtons.DeactivateDefaultButton();
    }
    
    private void UpdateText()
    {
        TMProUGUI_VolumeTitle.text = string_VolumeTitleDefault + Mathf.Round((slider_VolumeSlider.value / 1f) * 100) + "%";
    }
}
