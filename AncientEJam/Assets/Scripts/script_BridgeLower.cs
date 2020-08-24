﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_BridgeLower : MonoBehaviour
{ 
    bool one_switch_activated = false;
    Animator bridge_anim;

    private void Start()
    {
        bridge_anim = this.GetComponent<Animator>();
    }


    public void Activate()
    {
        if (one_switch_activated)
        {
            bridge_anim.SetBool("Lower", true);
        }
        else
        {
            one_switch_activated = true;
        }
    }


}
