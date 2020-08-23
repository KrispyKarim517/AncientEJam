using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class script_Boulder : MonoBehaviour
{

    Rigidbody rb;

    public float roll_speed = 0f;
    public float rotate_speed = 0f;

    private bool can_rotate = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 1f, roll_speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (can_rotate)
            this.transform.Rotate(new Vector3(1f, 0f, 0f), rotate_speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("Floor") && !collision.gameObject.tag.Equals("Player"))
        {
            can_rotate = false;
        }
    }
}
