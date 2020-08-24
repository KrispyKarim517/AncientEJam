using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    Dependencies: script_PopUpWindow, script_OptionsMenuButtons, script_AudioSlider
    
    A script that allows the user to map actions to different keys
*/
public class script_KeyMapping : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button[] arr_Buttons = new Button[6]; // The buttons
    [SerializeField] private TextMeshProUGUI[] arr_TMProForButtons = new TextMeshProUGUI[6]; // The buttons' TMPro text components (to be updated upon new key presses)
    private string[] arr_KeyMapNames = new string[6]; // The key mappings registered in the GameInputManager
    
    [Header("Notification Script")]
    [SerializeField] private script_PopUpWindow ref_PopUpWindow = null;
    
    [Header("Options Menu Buttons Script")]
    [SerializeField] private script_OptionsMenuButtons ref_OptionsMenuButtons = null;
    
    // KeyCodes that cannot be selected (because it would interfere with a different feature / be inconvenient
    private static KeyCode[] arr_ForbiddenKeyCodes = new KeyCode[7]
    {
        KeyCode.Mouse0,
        KeyCode.Mouse1,
        KeyCode.Mouse2,
        KeyCode.Mouse3,
        KeyCode.Mouse4,
        KeyCode.Mouse5,
        KeyCode.Mouse6,
    };
    
    // KeyCodes Renamed
    private static Dictionary<KeyCode, string> dict_KeyCodeNames = new Dictionary<KeyCode, string>
    {
        {KeyCode.Keypad0, "Numpad 0"},
        {KeyCode.Keypad1, "Numpad 1"},
        {KeyCode.Keypad2, "Numpad 2"},
        {KeyCode.Keypad3, "Numpad 3"},
        {KeyCode.Keypad4, "Numpad 4"}, 
        {KeyCode.Keypad5, "Numpad 5"}, 
        {KeyCode.Keypad6, "Numpad 6"}, 
        {KeyCode.Keypad7, "Numpad 7"},
        {KeyCode.Keypad8, "Numpad 8"},
        {KeyCode.Keypad9, "Numpad 9"},
        {KeyCode.KeypadPeriod, "Numpad ."},
        {KeyCode.KeypadDivide, "Numpad /"},
        {KeyCode.KeypadMultiply, "Numpad *"},
        {KeyCode.KeypadMinus, "Numpad -"}, 
        {KeyCode.KeypadPlus, "Numpad +"},
        {KeyCode.KeypadEnter, "Numpad Enter"},
        {KeyCode.KeypadEquals, "Numpad Equals"},
        {KeyCode.UpArrow, "Up"},
        {KeyCode.DownArrow, "Down"}, 
        {KeyCode.RightArrow, "Right"},
        {KeyCode.LeftArrow, "Left"},
        {KeyCode.PageUp, "Page Up"},
        {KeyCode.PageDown, "Page Down"},
        {KeyCode.Alpha0, "0"},
        {KeyCode.Alpha1, "1"},
        {KeyCode.Alpha2, "2"},
        {KeyCode.Alpha3, "3"},
        {KeyCode.Alpha4, "4"},
        {KeyCode.Alpha5, "5"},
        {KeyCode.Alpha6, "6"}, 
        {KeyCode.Alpha7, "7"}, 
        {KeyCode.Alpha8, "8"}, 
        {KeyCode.Exclaim, "!"},
        {KeyCode.DoubleQuote, "\""},
        {KeyCode.Hash, "#"}, 
        {KeyCode.Dollar, "$"},
        {KeyCode.Percent, "%"},
        {KeyCode.Ampersand, "&"},
        {KeyCode.Quote, "'"},
        {KeyCode.LeftParen, "("},
        {KeyCode.RightParen, ")"},
        {KeyCode.Asterisk, "*"},
        {KeyCode.Plus, "+"},
        {KeyCode.Comma, ","},
        {KeyCode.Minus, "-"},
        {KeyCode.Period, "."},
        {KeyCode.Slash, "/"},
        {KeyCode.Colon, ":"},
        {KeyCode.Semicolon, ";"},
        {KeyCode.Less, "<"},
        {KeyCode.Equals, "="},
        {KeyCode.Greater, ">"},
        {KeyCode.Question, "?"},
        {KeyCode.At, "@"},
        {KeyCode.LeftBracket, "["},
        {KeyCode.Backslash, "\\"},
        {KeyCode.RightBracket, "]"},
        {KeyCode.Caret, "^"},
        {KeyCode.Underscore, "_"},
        {KeyCode.BackQuote, "`"},
        {KeyCode.LeftCurlyBracket, "{"},
        {KeyCode.Pipe, "|"},
        {KeyCode.RightCurlyBracket, "}"},
        {KeyCode.Tilde, "~"},
        {KeyCode.Numlock, "Num Lock"},
        {KeyCode.CapsLock, "Caps Lock"},
        {KeyCode.ScrollLock, "Scroll Lock"},
        {KeyCode.RightShift, "Right Shift"},
        {KeyCode.LeftShift, "Left Shift"},
        {KeyCode.RightAlt, "Right Alt"},
        {KeyCode.LeftAlt, "Left Alt"},
        {KeyCode.AltGr, "Alt"},
        {KeyCode.SysReq, "System Req"} 
    };

    // Update the buttons' TMPro text components to have the correct keycodes displayed
    private void Awake()
    {
        arr_KeyMapNames = GameInputManager.GetKeyMaps();
        for (int i = 0; i < arr_KeyMapNames.Length; i++)
        {
            UpdateButtonText(i, arr_KeyMapNames[i]);
        }
    }
    
    // Update the button text to reflect the current keycode
    private void UpdateButtonText(int int_temp_ButtonArrIndex, string string_temp_keyMapName)
    {
        KeyCode keycode_temp_GameInputManagerKeyCodeResult = GameInputManager.GetKeyCode(string_temp_keyMapName);
        if (!dict_KeyCodeNames.ContainsKey(keycode_temp_GameInputManagerKeyCodeResult) && keycode_temp_GameInputManagerKeyCodeResult != KeyCode.None)
        {
            arr_TMProForButtons[int_temp_ButtonArrIndex].text = keycode_temp_GameInputManagerKeyCodeResult.ToString();
        }
        else if (dict_KeyCodeNames.ContainsKey(keycode_temp_GameInputManagerKeyCodeResult))
        {
            arr_TMProForButtons[int_temp_ButtonArrIndex].text = dict_KeyCodeNames[keycode_temp_GameInputManagerKeyCodeResult];
        }
        else
        {
            arr_TMProForButtons[int_temp_ButtonArrIndex].text = "";
        }
    }
    
    // Used to connect a button press to the register key press event
    public void RegisterKey(string string_temp_keyMapName)
    {
        int int_temp_keyMapNameIndex = Array.IndexOf(arr_KeyMapNames, string_temp_keyMapName);
        for (int i = 0; i < arr_TMProForButtons.Length; ++i)
        {
            if (i != int_temp_keyMapNameIndex)
            {
                arr_Buttons[i].interactable = false;
            }
        }
        StartCoroutine(GetNextKeyPress(string_temp_keyMapName));
    }
    
    // Waits until it receives input
    private IEnumerator GetNextKeyPress(string string_temp_keyMapName)
    {
        ref_PopUpWindow.UpdateMessage("Waiting for input . . .");
        while (!CheckKeyForKeyRegistration(string_temp_keyMapName))
        {
            if (CheckKeyForKeyRegistration(string_temp_keyMapName))
            {
                yield break;
            }
            yield return null;
        }
    }
    
    // Returns true if input was detected
    // Used as a break condition for the while loop in GetNextKeyPress
    private bool CheckKeyForKeyRegistration(string string_temp_newKeyMapName)
    {
        foreach (KeyCode keycode_temp_key in Enum.GetValues(typeof(KeyCode)))
        {
            KeyCode keycode_temp_lastKeyCode = GameInputManager.GetKeyCode(string_temp_newKeyMapName);
            if (Input.GetKeyDown(keycode_temp_key) && !arr_ForbiddenKeyCodes.Contains(keycode_temp_key ))
            {
                if (!GameInputManager.ContainsKeyCode(keycode_temp_key)) // If the key mapping does not contain this key, re-map
                {
                    BindMapToKey(string_temp_newKeyMapName, keycode_temp_key);
                }
                else // If it does, replace the old key mapping will KeyCode.None and the new key mapping with the current key
                {
                    string string_temp_oldKeyMapName = GameInputManager.GetKeyMapName(keycode_temp_key);
                    BindMapToKey(string_temp_oldKeyMapName, KeyCode.None);
                    BindMapToKey(string_temp_newKeyMapName, keycode_temp_key);
                }
                if (GameInputManager.CheckForNoKeyCode())
                {
                    ref_PopUpWindow.UpdateMessage("All controls must be bound to a key.");
                    ref_OptionsMenuButtons.DeactivateExitButton();
                }
                else
                {
                    ref_PopUpWindow.ClearMessage();
                    ref_OptionsMenuButtons.ActivateExitButton();
                }
                if (keycode_temp_lastKeyCode != keycode_temp_key)
                {   
                    ref_OptionsMenuButtons.ActivateDefaultButton();
                }
                ResetButtons();
                return true;
            }
        }
        return false;
    }
    
    // Maps a control to a keycode
    private void BindMapToKey (string string_temp_keyMapName, KeyCode keycode_temp_key)
    {
        GameInputManager.SetKeyMap(string_temp_keyMapName, keycode_temp_key);
        UpdateButtonText(Array.IndexOf(arr_KeyMapNames, string_temp_keyMapName), string_temp_keyMapName);
    }
    
    // Sets the buttons to their default bindings
    public void SetButtonsToDefaultBindings()
    {
        GameInputManager.ResetAllKeys();
        for (int i = 0; i < arr_KeyMapNames.Length; i++)
        {
            UpdateButtonText(i, arr_KeyMapNames[i]);
        }
        ref_OptionsMenuButtons.DeactivateDefaultButton();
        ref_OptionsMenuButtons.ActivateExitButton();
    }
    
    // Reset the buttons to an interactable state
    private void ResetButtons()
    {
        for (int i = 0; i < arr_TMProForButtons.Length; ++i)
        {
            arr_Buttons[i].interactable = true;
        }
    }
}