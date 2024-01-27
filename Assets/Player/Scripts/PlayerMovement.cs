using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float move_speed = 0;
    [SerializeField] private float acceleration = 15;
    [SerializeField] private float max_speed = 5;
    [SerializeField] private float deceleration = 20;
    [SerializeField] private float jump_force = 10;
    [SerializeField] private LayerMask groundLayer;

    private float x = 0;
    private bool grounded = false;
    private float last_y_pos = 0;
    private float distToGround = 0;
    //private Collider2D collider;


    private void Start()
    {
        last_y_pos = transform.position.y;
        //collider = transform.GetComponent<Collider2D>();
        //distToGround = collider.bounds.extents.y;
    }


    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        

        if (x == 1)
        {
            if (move_speed < max_speed)
            {
                move_speed += acceleration * Time.deltaTime;
            }
        }
        else if (x == -1)
        {
            if (move_speed > -max_speed)
            {
                move_speed -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (move_speed > 0)
            {
                move_speed -= deceleration * Time.deltaTime;
            }
            else if (move_speed < 0)
            {
                move_speed += deceleration * Time.deltaTime;
            }
            if(move_speed < 0.1 && move_speed > -0.1)
            {
                move_speed = 0;
            }
        }
        transform.position = new Vector3(transform.position.x+move_speed*Time.deltaTime, transform.position.y, transform.position.z);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Yes");
            Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
        }

        // Grounded check
        //if (last_y_pos == transform.position.y)
        //{
        //    grounded = true;
        //}
        //else
        //{
        //    grounded = false;
        //    last_y_pos = transform.position.y;
        //}
        grounded = isGrounded();
        Debug.Log(grounded);

    }

    private bool isGrounded()
    {
        //return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f, collider.bounds.center.z), 0.18f);
        //return Physics.Raycast(transform.position, Vector3.down, distToGround+1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }



}
