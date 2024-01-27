using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float move_speed = 0;
    [SerializeField] private float acceleration = 1;
    [SerializeField] private float max_speed = 5;
    [SerializeField] private float deceleration = 1;

    private float x = 0;

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


    }





}
