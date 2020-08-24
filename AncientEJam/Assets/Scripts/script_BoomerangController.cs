using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_BoomerangController : Gear
{
    public GameObject boomerangPrefab;

    private Transform m_Parent;

    void Start()
    {
        m_Parent = transform.parent;
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
        GameObject boomerang = Instantiate(boomerangPrefab, transform.position, Quaternion.Euler(0,0,0));
        boomerang.GetComponent<script_BoomerangBehavior>().StartBoomerang(m_Parent);
        ToggleRenderer();
        boomerang.GetComponent<script_BoomerangBehavior>().EndEvent.AddListener(ToggleRenderer);
    }

    private void ToggleRenderer()
    {
        foreach(MeshRenderer m in this.GetComponentsInChildren<MeshRenderer>())
        {
            m.enabled = !m.enabled;
        }
    }
}
