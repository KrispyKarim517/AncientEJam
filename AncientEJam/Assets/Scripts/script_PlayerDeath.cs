using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerDeath : MonoBehaviour
{
    public void EndGame()
    {
        Debug.LogError("GAME OVER");
        Destroy(this.gameObject);
    }
}
