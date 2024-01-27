using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickup : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text score_text;
    [SerializeField] AudioClip pickup_clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "balloon_animal")
        {
            score++;
            score_text.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);

            GetComponent<AudioSource>().PlayOneShot(pickup_clip);
        }
    }
}
