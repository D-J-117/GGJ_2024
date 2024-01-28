using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            Destroy(gameObject.transform.parent.gameObject);
            other.GetComponent<Enemy1>().MakeHappy();
        }
    }
}
