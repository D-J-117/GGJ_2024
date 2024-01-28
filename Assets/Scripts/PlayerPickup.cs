using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerPickup : MonoBehaviour
{
    public int score = 0;
    public TMP_Text score_text;
    [SerializeField] AudioClip pickup_clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalloonAnimal")
        {
            score++;
            score_text.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);

            GetComponent<AudioSource>().PlayOneShot(pickup_clip);
        }
        else if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
