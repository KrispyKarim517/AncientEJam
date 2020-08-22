using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerController : MonoBehaviour
{
    public bool enabledKeyboard = true;
    public GameObject model;

    private float m_movementSpeed = 5.0f;
    private Vector3 direction;
    private bool canMove = true;
    private bool canFire = true;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        model = this.gameObject;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard Controls:
        // WASD to move
        // Mouse to aim
        // Left Click to use current item
        if (enabledKeyboard)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Fire();
            
            Move(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized);
            Rotate();
        }

        m_rigidbody.velocity = direction * m_movementSpeed;
    }

    public void Move(Vector3 inputDirection) 
    {
        direction = inputDirection;
    }

    public void Rotate() 
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength)) 
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    public void Fire() 
    {
        if (canFire) 
        {
            StartCoroutine(fireEnumerator());
        }
    }

    IEnumerator fireEnumerator() 
    {
        canFire = false;
        // Instantiate some bullet or use item.
        yield return new WaitForSeconds(0.3f); // You can modify the wait time to spam an item
        canFire = true;
    }



    public float GetMovementSpeed() { return m_movementSpeed; }
    public void SetMovementSpeed(float f) { m_movementSpeed = f; }
    public Vector2 GetDirection() { return direction; }
    public void SetDirection(Vector2 dir) { direction = dir; }
    public bool GetCanMove() { return canMove; }
    public void SetCanMove(bool b) { canMove = b; }
    public void SetCanFire(bool b) { canFire = b; }
}
