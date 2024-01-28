using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int health = 3;

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Dead");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }

    public void makeHappy()
    {
        GetComponent<Animator>().SetBool("Happy", true);
    }
}
