using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class script_LevelOneTrapTrigger : MonoBehaviour
{

    public UnityEvent TripTriggerEnteredEvent = new UnityEvent();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            TripTriggerEnteredEvent.Invoke();
        }
    }
}
