using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_BoomerangController : Gear
{
    public GameObject boomerangPrefab;

    private Transform m_Parent;
    private MeshRenderer m_Renderer;

    void Start()
    {
        m_Parent = transform.parent;
        m_Renderer = this.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Use();
        }
    }

    public override void Use()
    {
        GameObject boomerang = Instantiate(boomerangPrefab);
        ToggleRenderer();
        boomerang.GetComponent<script_BoomerangBehavior>().EndEvent.AddListener(ToggleRenderer);
    }

    private void ToggleRenderer()
    {
        m_Renderer.enabled = !m_Renderer.enabled;
    }
}
