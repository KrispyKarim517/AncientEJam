using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_MagnetCollider : MonoBehaviour
{
    [SerializeField] GameObject player = null;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        var target_comp = other.GetComponent<script_MagTarget>();
        if (target_comp != null)
        {
            Debug.Log("HIT");
            Transform temp = player.transform;
            target_comp.Activate(ref temp);
            player.transform.position = temp.position;
        }
    }
}
