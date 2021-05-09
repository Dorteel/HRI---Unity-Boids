using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Movement : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;

    public Rigidbody2D rb;
    //public Camera cam;

    float angle = 0;
    float movement = 0;
    Vector2 mousePos;
    Vector2 moveDirection;

    // Update is called once per frame
    void Update ()
    {
        angle = Input.GetAxisRaw("Horizontal");
        movement = Input.GetAxisRaw("Vertical");
        
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //

        //Vector2 lookDir = mousePos - rb.position;
        moveDirection = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * rb.rotation), Mathf.Cos(Mathf.Deg2Rad * rb.rotation));
        //rb.velocity = new Vector2(moveDirection.x * movement * moveSpeed * Time.fixedDeltaTime, moveDirection.y * movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime * movement);
        //pepper.position += pepper.forward * Time.fixedDeltaTime * moveSpeed;
        rb.rotation = rb.rotation - angle * rotationSpeed * Time.fixedDeltaTime * Mathf.Rad2Deg;
    }
}
