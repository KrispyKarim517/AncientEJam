using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    
    A script that controls the main menu
*/
public class script_MainMenu : MonoBehaviour
{
     public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Options()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<script_UIManager>().DisplayOptionsMenu(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
