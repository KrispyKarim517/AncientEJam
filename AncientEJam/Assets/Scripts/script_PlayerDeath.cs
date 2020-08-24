using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen = null;

    public void EndGame()
    {
        Debug.LogError("GAME OVER");
        Destroy(this.gameObject);
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
    }
}
