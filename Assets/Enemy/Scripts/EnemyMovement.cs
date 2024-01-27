using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;  
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
        Debug.Log(collide);
       
        if (currentPos == pointB.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else if (currentPos == pointA.transform)
        {
            rigid.velocity = new Vector2 (-speed, 0);
        }


        if (currentPos == pointC.transform)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else if (currentPos == pointD.transform)
        {
            rigid.velocity = new Vector2(-speed, 0);
        }

        if ((collide && (currentPos = pointB.transform)) || (collide && (currentPos = pointB.transform)))
        {
            currentPos = pointA.transform;
        }

        if ((collide && (currentPos = pointA.transform)) || (collide && (currentPos = pointD.transform)))
        {
            currentPos = pointB.transform;
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointB.transform)
        {
            currentPos = pointA.transform;
        }


        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointA.transform)
        {
            currentPos = pointB.transform;       
        }


        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointD.transform)
        {
            currentPos = pointC.transform;
        }


        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == pointC.transform)
        {
            currentPos = pointD.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
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
