using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    AUTHOR: Nichole Wong
    UNITY VERSION: 2020.1.0f1
    LAST MODIFIED: 8/24/2020
    Dependencies: script_PlayerInteraction
    
    A script that controls the tools displayed
*/
public class script_ToolDisplayUI : MonoBehaviour
{
    [SerializeField] private Image[] arr_ToolImages = new Image[4];
    [Range(0f, 1f)][SerializeField] private float float_MinAlpha = .5f;
    private script_PlayerInteraction ref_PlayerInteraction = null;
    private Color color_defaultImageColor = new Color(1f, 1f, 1f, 1f);
    
    private void Awake()
    {
        GameObject gobj_temp_player = GameObject.FindGameObjectWithTag("Player");
        ref_PlayerInteraction = gobj_temp_player.GetComponent<script_PlayerInteraction>();
        color_defaultImageColor = arr_ToolImages[0].color;
        for (int i = 1; i < arr_ToolImages.Length; ++i)
        {
            UpdateImageAlpha(i, float_MinAlpha);
        }
    }
    
    public void CycleThroughTools()
    {
        if (ref_PlayerInteraction.GetIndex() == 0)
        {
            UpdateImageAlpha(arr_ToolImages.Length - 1, float_MinAlpha);
            UpdateImageAlpha(0, 1f);
        }
        else
        {
            UpdateImageAlpha(ref_PlayerInteraction.GetIndex() - 1, float_MinAlpha);
            UpdateImageAlpha(ref_PlayerInteraction.GetIndex(), 1f);
        }
    }
    
    private void UpdateImageAlpha(int int_temp_index, float float_temp_newAlpha)
    {
        color_defaultImageColor.a = float_temp_newAlpha;
        arr_ToolImages[int_temp_index].color = color_defaultImageColor;
    }
}
