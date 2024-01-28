using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            //other.GetComponent<Enemy>().makeHappy();
        }
    }
}
