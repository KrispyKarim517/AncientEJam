using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_CameraFollowPlayer : MonoBehaviour
{
    public GameObject player1;
    public float smoothTime = 0.3f;
    public float maxSpeed = 3f;
    private Vector3 velocity = Vector3.zero;

    private float xOffset;
    private float zOffset;

    void Start()
    {
        xOffset = transform.position.x;
        zOffset = transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 target = new Vector3(player1.transform.position.x + xOffset, transform.position.y, player1.transform.position.z + zOffset);

        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime, maxSpeed);
    }
}