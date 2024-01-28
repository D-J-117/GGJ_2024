using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD:Assets/Player/Scripts/PlayerDamage.cs
=======
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
>>>>>>> Elijah2:Assets/Enemy/Scripts/EnemyMovement.cs
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int health = 3;

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Dead");

<<<<<<< HEAD:Assets/Player/Scripts/PlayerDamage.cs
        }
=======
    private void Enemy_Movement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
>>>>>>> Elijah2:Assets/Enemy/Scripts/EnemyMovement.cs
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }

<<<<<<< HEAD:Assets/Player/Scripts/PlayerDamage.cs

=======
    public void makeHappy()
    {
        GetComponent<Animator>().SetBool("Happy", true);
    }
>>>>>>> Elijah2:Assets/Enemy/Scripts/EnemyMovement.cs
}
