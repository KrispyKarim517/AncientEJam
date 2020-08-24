using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    
    A script that controls the message that gets displayed on the pop-up window
*/
public class script_PopUpWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMProUGUI_Message = null;
    
    public void UpdateMessage(string string_temp_newMessage)
    { 
        TMProUGUI_Message.text = string_temp_newMessage;
    }
    
    public void ClearMessage()
    {
        TMProUGUI_Message.text = "";
    }
}
