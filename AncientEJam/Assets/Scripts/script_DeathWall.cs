using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class script_DeathWall : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        rb.velocity = new Vector3(1f, 0f, 0f) * speed;
    }
}
