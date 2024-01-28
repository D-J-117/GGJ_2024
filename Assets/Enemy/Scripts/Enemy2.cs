using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject pointC;
    public GameObject pointD;  
    public Rigidbody2D rigid;

    [SerializeField]
    private float speed = 2f;
    private bool collide = false;
    private Transform EnemyDirection2;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        EnemyDirection2 = pointD.transform;
    }

    void Update()
    {
        Debug.Log("enemy 2" + collide);

        //D AND C
        if (EnemyDirection2 == pointC.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else if (EnemyDirection2 == pointD.transform)
        {
            rigid.velocity = new Vector2(-speed, 0);
        }

        //D AND C
        if (collide && (EnemyDirection2 = pointD.transform))
        {
            EnemyDirection2 = pointC.transform;
        }

        if (collide && (EnemyDirection2 = pointC.transform))
        {
            EnemyDirection2 = pointD.transform;
        }

        //D AND C
        if (Vector2.Distance(transform.position, EnemyDirection2.position) < 0.5f && EnemyDirection2 == pointD.transform)
        {
            EnemyDirection2 = pointC.transform;
        }


        if (Vector2.Distance(transform.position, EnemyDirection2.position) < 0.5f && EnemyDirection2 == pointC.transform)
        {
            EnemyDirection2 = pointD.transform;
        }
    }

    private void OnDrawGizmos()
    {
        //D AND C
        Gizmos.DrawWireSphere(pointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.5f);
        //D AND C
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
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
