using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;  
    public Rigidbody2D rigid;

    [SerializeField]
    private float speed = 2f;
    private bool collide = false;
    private Transform EnemyDirection1;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EnemyDirection1 = pointB.transform;
    }

    void Update()
    {
        Debug.Log("enemy 1" + collide);
       
        //B AND A
        if (EnemyDirection1 == pointB.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else if (EnemyDirection1 == pointA.transform)
        {
            rigid.velocity = new Vector2 (-speed, 0);
        }

        //A AND B
        if (collide && (EnemyDirection1 = pointB.transform))
        {
            EnemyDirection1 = pointA.transform;
        }

        if (collide && (EnemyDirection1 = pointA.transform))
        {
            EnemyDirection1 = pointB.transform;
        }

        //A AND B
        if (Vector2.Distance(transform.position, EnemyDirection1.position) < 0.5f && EnemyDirection1 == pointB.transform)
        {
            EnemyDirection1 = pointA.transform;
        }


        if (Vector2.Distance(transform.position, EnemyDirection1.position) < 0.5f && EnemyDirection1 == pointA.transform)
        {
            EnemyDirection1 = pointB.transform;       
        }
    }

    private void OnDrawGizmos()
    {
        //A AND B
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        //A AND B
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           
            if (!collide)
            {
                collide = true;
               
            }
           

            // damage function call within player.
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collide = false;
        }
    }
}
