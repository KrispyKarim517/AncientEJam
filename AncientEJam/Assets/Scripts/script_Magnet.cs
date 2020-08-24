using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Magnet : Gear
{
    [SerializeField] Collider grab_range_trigger = null;



    public override void Use()
    {
        grab_range_trigger.enabled = !grab_range_trigger.enabled;
    }

    public override void UnUse()
    {
        grab_range_trigger.enabled = false;
    }
}

