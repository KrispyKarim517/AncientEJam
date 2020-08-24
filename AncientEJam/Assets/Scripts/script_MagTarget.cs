using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_MagTarget : MonoBehaviour
{
    [SerializeField] GameObject teleport_destination = null;

    public void Activate(ref Transform player_loc)
    {
        player_loc = teleport_destination.transform;
    }
}
