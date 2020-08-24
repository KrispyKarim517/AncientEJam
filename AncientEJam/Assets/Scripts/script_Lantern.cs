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
            ring.SetActive(true);
        }
        else
        {
            ring.SetActive(false);
        }
    }
}
