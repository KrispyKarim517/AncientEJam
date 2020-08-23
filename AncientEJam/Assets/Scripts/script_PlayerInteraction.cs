using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerInteraction : MonoBehaviour
{
    [Header("Gear Pieces")]
    [SerializeField] Gear lantern   = null;
    [SerializeField] Gear sword     = null;
    [SerializeField] Gear manget    = null;
    [SerializeField] Gear boomerang = null;

    private Gear current_gear = null;

    private void Start()
    {
        SetGear("sword");
    }


    public void SetGear(string gear)
    {
        if (current_gear != null)
            current_gear.gameObject.SetActive(false);
        switch (gear)
        {
            case "boomerang":
                current_gear = boomerang;
                break;
            case "sword":
                current_gear = sword;
                break;
            case "magnet":
                current_gear = manget;
                break;
            case "lantern":
                current_gear = lantern;
                break;
        }
        current_gear.gameObject.SetActive(true);
    }


    public Gear GetGear()
    {
        return current_gear;
    }
}
