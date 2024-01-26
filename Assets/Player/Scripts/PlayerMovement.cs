using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int move_speed = 10;
    private float x = 0;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector3(transform.position.x+x*move_speed*Time.deltaTime, transform.position.y, transform.position.z);
    
    }

  



}
