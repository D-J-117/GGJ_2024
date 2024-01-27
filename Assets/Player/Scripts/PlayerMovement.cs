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
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(move_speed, rb.velocity.y);

        //transform.position = new Vector3(transform.position.x+move_speed*Time.deltaTime, transform.position.y, transform.position.z);


        // Jumping
        grounded = isGrounded();
        Debug.Log(grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Yes");
            Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
            grounded = false;
        }


    }

    private bool isGrounded()
    {
        // Cast 3 rays to check for grounded collision, one from left side, one from centre, one from right

        Collider2D collider = transform.GetComponent<Collider2D>();
        

        Vector2 pos_min = new Vector2(collider.bounds.center.x - collider.bounds.extents.x, transform.position.y);
        Vector2 pos_max = new Vector2(collider.bounds.center.x + collider.bounds.extents.x, transform.position.y);


        Debug.Log(pos_min);
        Debug.Log(pos_max);

        RaycastHit2D hit_centre = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
        RaycastHit2D hit_left = Physics2D.Raycast(pos_min, Vector2.down, 0.5f, groundLayer);
        RaycastHit2D hit_right = Physics2D.Raycast(pos_max, Vector2.down, 0.5f, groundLayer);

        if (hit_left.collider != null || hit_centre.collider != null || hit_right.collider != null)
        {
            return true;
        }
        return false;

    }



}
