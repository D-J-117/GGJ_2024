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
    private bool face_right = true;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Debug.Log(grounded);
        x = Input.GetAxisRaw("Horizontal");
        

        if (x == 1)
        {
            if (move_speed < max_speed)
            {
                move_speed += acceleration * Time.deltaTime;
            }
            if (!face_right)
            {
                face_right = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
        }
        else if (x == -1)
        {
            if (move_speed > -max_speed)
            {
                move_speed -= acceleration * Time.deltaTime;
            }
            if (face_right)
            {
                face_right = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
            if(move_speed < 0.5 && move_speed > -0.5)
            {
                move_speed = 0;
            }
        }
        rb.velocity = new Vector2(move_speed, rb.velocity.y);

    }

    private void Update()
    {
        // The program encountered an issue when processing the jump logic in FixedUpdate,
        // where the Player would rarely jump when te input was pressed, even if grounded was True
        
        // Jumping
        grounded = isGrounded();

        if (Input.GetButtonDown("Jump"))// && grounded)
        {
            Debug.Log("jump");
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
