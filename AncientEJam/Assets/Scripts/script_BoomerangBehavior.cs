using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class script_BoomerangBehavior : MonoBehaviour
{
    public static script_BoomerangBehavior instance = null;

    private Vector3 startingLocation;
    private Vector3 velocity = Vector3.zero;
    private bool started;

    public Vector3 Target;
    public float throwTimeToTarget = 1f;
    public float throwDistance = 5f;

    public float spinSpeed = 1f;

    public UnityEvent EndEvent = new UnityEvent();

    private List<string> soundTitles;// = new List<string>() {"boomer_goingstart"};


    public void StartBoomerang(Transform loc)
    {
        startingLocation = loc.position;
        Target = startingLocation + (loc.forward * throwDistance);
        started = true;
    }

    void Awake() 
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        soundTitles = new List<string>() {"boomer_goingstart"};
    }

    void Update()
    {
        if(started)
            Move();
        Spin();

        string title = soundTitles[UnityEngine.Random.Range(0, soundTitles.Count)];

        script_AudioManager.instance.PlaySound(title, null, false, script_AudioManager.instance.maxVolume);
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
        transform.Rotate(new Vector3(0,spinSpeed,0));
    }

    private void OnCollisionEnter(Collision collsiion) 
    {
        Destroy(this.gameObject);
        // Target = startingLocation;

    }
}
