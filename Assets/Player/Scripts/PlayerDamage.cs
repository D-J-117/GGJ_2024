using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public int health = 3;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var pos1 = transform.position;
            var pos2 = collision.gameObject.transform.position;

            var gradient = (pos2.y-pos1.y) / (pos2.x-pos1.x);

            if (gradient < 1 && gradient > -1)
            {
                health--;
                if (health <= 0)
                {
                    Debug.Log("Dead");

                }
            }
            else
            {
                Debug.Log("Stomped");
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

            }

        }
    }



}
