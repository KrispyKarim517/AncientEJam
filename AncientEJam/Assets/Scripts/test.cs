using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        script_AudioManager.instance.PlaySound("boomer_going");
    }
}
