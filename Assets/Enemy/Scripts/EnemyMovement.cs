using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private void Update()
    {
        Enemy_Movement();
    }

    private void Enemy_Movement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Enter");
            transform.Translate(-Vector2.left * speed * Time.deltaTime);
            // damage function call within player.
        }
    }

    public void makeHappy()
    {

    }
}
