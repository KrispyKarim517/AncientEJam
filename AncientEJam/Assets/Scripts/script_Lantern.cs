using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Lantern : Gear
{
    public GameObject ring;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Use();
        }
    }

    public override void Use()
    {
        if(ring.activeSelf == false)
        {
            script_AudioManager.instance.PlaySound("lantern", null, false, script_AudioManager.instance.maxVolume);
            ring.SetActive(true);
        }
        else
        {
            ring.SetActive(false);
        }
    }
}
