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

        grounded = isGrounded();
        Debug.Log(grounded);

    }

    private bool isGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }



}
