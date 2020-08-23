﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class script_BoomerangBehavior : MonoBehaviour
{
    private Vector3 startingLocation;
    private Vector3 velocity = Vector3.zero;

    public Vector3 Target;
    public float throwTimeToTarget = 1f;
    public float throwDistance = 5f;

    public UnityEvent EndEvent = new UnityEvent();

    void Start()
    {
        startingLocation = this.transform.position;
        Target = startingLocation + (transform.forward * throwDistance);
    }

    void Update()
    {
        Move();
        Spin();
    }

    private void Move()
    {
        transform.position = Vector3.SmoothDamp(transform.position,Target, ref velocity, throwTimeToTarget);
        Vector3 difference = Target - transform.position;
        if(difference.magnitude <= .5f)
        {
            if(Target == startingLocation)
            {
                EndEvent.Invoke();
                Destroy(this.gameObject);
            }

            Target = startingLocation;
        }
    }

    private void Spin()
    {
        transform.Rotate(new Vector3(0,1,0));
    }
}