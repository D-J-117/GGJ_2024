using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject left;
    public GameObject right;  
    public Rigidbody2D rigid;

    [SerializeField]
    private float speed = 2f;
    private bool collide = false;
    private Transform EnemyDirection1;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EnemyDirection1 = right.transform;
    }

    void Update()
    {
        Debug.Log("enemy 1" + collide);
       
        //B AND A
        if (EnemyDirection1 == right.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else if (EnemyDirection1 == left.transform)
        {
            rigid.velocity = new Vector2 (-speed, 0);
        }

        //A AND B
        if (collide && (EnemyDirection1 = right.transform))
        {
            EnemyDirection1 = left.transform;
        }

        if (collide && (EnemyDirection1 = left.transform))
        {
            EnemyDirection1 = right.transform;
        }

        //A AND B
        if (Vector2.Distance(transform.position, EnemyDirection1.position) < 0.5f && EnemyDirection1 == right.transform)
        {
            EnemyDirection1 = left.transform;
        }


        if (Vector2.Distance(transform.position, EnemyDirection1.position) < 0.5f && EnemyDirection1 == left.transform)
        {
            EnemyDirection1 = right.transform;       
        }
    }

    private void OnDrawGizmos()
    {
        //A AND B
        Gizmos.DrawWireSphere(left.transform.position, 0.5f);
        Gizmos.DrawWireSphere(right.transform.position, 0.5f);
        //A AND B
        Gizmos.DrawLine(left.transform.position, right.transform.position);
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
