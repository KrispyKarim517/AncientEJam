using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PitReveal : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lantern")
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lantern")
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}
