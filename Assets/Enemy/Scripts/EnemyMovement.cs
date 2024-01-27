using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D rigid;

    [SerializeField]
    private float speed = 2f;
    private bool collide = false;
    private Transform currentPos;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentPos = pointB.transform;
    }

    void Update()
    {
        if (collide && (rigid.velocity.x == 1))
        {
            rigid.velocity = new Vector2(-speed, 0);
        }
        if (collide && (rigid.velocity.x == -1))
        {
            rigid.velocity = new Vector2(speed, 0);
        }

        Vector2 point = currentPos.position - transform.position;
        if (currentPos == pointB.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigid.velocity = new Vector2 (-speed, 0);
        } 
            
        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointB.transform)
        {
            currentPos = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointA.transform)
        {
            currentPos = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Enter");
            if (!collide)
            {
                collide = true;
                Debug.Log(collide);
            }
            else
            {
                collide = false;
                Debug.Log(collide);
            }
           

            // damage function call within player.
        }
    }
}
