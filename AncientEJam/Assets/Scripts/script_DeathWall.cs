using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class script_DeathWall : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = .1f;

    private bool can_move = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (can_move)
            rb.velocity = new Vector3(1f, 0f, 0f) * speed;
    }

    public void WhenPassedTrigger()
    {
        can_move = true;
    }
}
