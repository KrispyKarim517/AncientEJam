using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from this video: 
// https://www.youtube.com/watch?v=hT-dyANbHDY&list=PLdgLYFdStKu2RTKC6f9LhIC2Xb6eJfRag&index=3&t=0s

public class script_CameraFollowPlayer : MonoBehaviour
{
    script_PlayerController player;
    public bool followPlayer = true;
    Vector3 mousePos;

    private void Start() 
    {
        player = script_PlayerController.instance;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            followPlayer = false;
            player.canMove = false;
        }
        else 
        {
            followPlayer = true;
            player.canMove = true;
        }
        if (followPlayer)
            camFollowPlayer();
        else
            lookAhead();
    }

    private void camFollowPlayer() 
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    private void lookAhead() 
    {
        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camPos.z = 10;
        Vector3 dir = camPos - this.transform.position;
        transform.Translate(dir * 2 * Time.deltaTime);

    }
}
