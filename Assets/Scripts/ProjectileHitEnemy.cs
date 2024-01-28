using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ProjectileHitEnemy : MonoBehaviour
{
    public PlayerPickup player_pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            //player_pickup.score++;
            //player_pickup.score_text.text = "Score: " + player_pickup.score.ToString();
            Destroy(gameObject.transform.parent.gameObject);
            other.GetComponent<Enemy1>().MakeHappy();
        }
    }
}
