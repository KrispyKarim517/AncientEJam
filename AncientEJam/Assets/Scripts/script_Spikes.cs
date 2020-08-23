using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Spikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            var death_component = other.gameObject.GetComponent<script_PlayerDeath>();
            if (death_component != null)
            {
                death_component.EndGame();
            }
        }
    }
}
