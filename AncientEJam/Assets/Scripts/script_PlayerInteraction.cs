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
    string[] gear_arr;
    int index = 0;
    [SerializeField] script_ToolDisplayUI ref_ToolDisplayUI = null;

    private Gear current_gear = null;

    private void Start()
    {
        SetGear("lantern");
        gear_arr = new string[4] {"lantern", "boomerang", "sword", "magnet"};
    }
    private void Update()
    {
        if (GameInputManager.GetKeyDown("Cycle"))
        {
            index = (index != 3) ? index + 1 : 0;
            SetGear(gear_arr[index]);
            ref_ToolDisplayUI.CycleThroughTools();
        }
        else if (GameInputManager.GetKeyDown("Interact"))
        {
            if (current_gear == manget)
            {
                current_gear.Use();
            }
        }
    }

    public void SetGear(string gear)
    {
        if (current_gear != null)
        {
            current_gear.gameObject.SetActive(false);
            current_gear.UnUse();
        }
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
    
    public int GetIndex()
    {
        return index;
    }
}
