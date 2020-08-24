using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    
    A script that controls the buttons on the options menu
*/
public class script_OptionsMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject gobj_OptionsMenu = null;
    [SerializeField] private Button button_DefaultsButton = null;
    [SerializeField] private TextMeshProUGUI TMProUGUI_DefaultButtonText = null;
    [SerializeField] private Button button_ExitButton = null;
    [SerializeField] private TextMeshProUGUI TMProUGUI_ExitButtonText = null;
    [SerializeField] private float float_TMProAlpha = .5f;
    private Color color_tmp_ButtonColor = new Color(1f, 1f, 1f, 1f);
    
    private void Awake()
    {
        button_DefaultsButton.interactable = false;
        color_tmp_ButtonColor = TMProUGUI_DefaultButtonText.color;
        SetAlpha(float_TMProAlpha, TMProUGUI_DefaultButtonText);
    }
    
    public void ActivateDefaultButton()
    {
        button_DefaultsButton.interactable = true;
        color_tmp_ButtonColor = TMProUGUI_DefaultButtonText.color;
        SetAlpha(1f, TMProUGUI_DefaultButtonText);
    }
    
    public void DeactivateDefaultButton()
    {
        button_DefaultsButton.interactable = false;
        color_tmp_ButtonColor = TMProUGUI_DefaultButtonText.color;
        SetAlpha(float_TMProAlpha, TMProUGUI_DefaultButtonText);
    }
    
    public void ActivateExitButton()
    {
        button_ExitButton.interactable = true;
        color_tmp_ButtonColor = TMProUGUI_ExitButtonText.color;
        SetAlpha(1f, TMProUGUI_ExitButtonText);
    }
    
    public void DeactivateExitButton()
    {
        button_ExitButton.interactable = false;
        color_tmp_ButtonColor = TMProUGUI_ExitButtonText.color;
        SetAlpha(float_TMProAlpha, TMProUGUI_ExitButtonText);
    }
    
    public void SetAlpha(float float_temp_newAlphaValue, TextMeshProUGUI TMProUGUI_temp_TMProButtonText)
    {
        color_tmp_ButtonColor.a = float_temp_newAlphaValue;
        TMProUGUI_temp_TMProButtonText.color = color_tmp_ButtonColor;
    }
    
    public void OnExit()
    {
        gobj_OptionsMenu.SetActive(false);
    }
}
