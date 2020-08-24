using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/23/2020
    
    A script that allows the user to map actions to different keys
*/
public class script_KeyMapping : MonoBehaviour
{
    void Update()
    {
        foreach (KeyCode k in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(k))
            {
                Debug.Log(k);
            }
        }
    }

}
