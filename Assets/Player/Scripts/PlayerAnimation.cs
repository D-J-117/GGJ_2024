using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rb.velocity.x != 0)
        {
            transform.GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("IsMoving", false);
        }
    }
}
