using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerDeath : MonoBehaviour
{
    
    //[SerializeField] GameObject GameOverScreen = null;

    public void EndGame()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<script_UIManager>().DisplayGameOverMenu(true);
        Destroy(this.gameObject);
        Time.timeScale = 0f;
    }
}
