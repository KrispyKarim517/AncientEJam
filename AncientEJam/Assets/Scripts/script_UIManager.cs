using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    
    A script that keeps a reference to the options menu and pause menu
*/
public class script_UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gobj_OptionsMenu = null;
    [SerializeField] private GameObject gobj_PauseMenu = null;
    // private bool bool_IsPauseMenuActive = false;
    
    private static script_UIManager instance_UIManager;
    
    private void Awake()
    {
        if (!instance_UIManager) instance_UIManager = this;
        else Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex > 0)
        {
                DisplayPauseMenu();
        }
    }
    
    public void DisplayOptionsMenu(bool bool_temp_isVisible)
    {
        gobj_OptionsMenu.SetActive(bool_temp_isVisible);
    }
    
    public void DisplayPauseMenu()
    {
        if (Time.timeScale == 1f) // Check if the game is running
        {
            gobj_PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gobj_PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    /*public void DisplayPauseMenu(bool bool_temp_isVisible)
    {
        if (bool_temp_isVisible)
        {
            gobj_PauseMenu.SetActive(bool_IsPauseMenuActive);
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            gobj_PauseMenu.SetActive(bool_IsPauseMenuActive);
        }
        bool_IsPauseMenuActive = !bool_IsPauseMenuActive;
    }*/
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        DisplayPauseMenu();
    }
}
