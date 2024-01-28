using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float speed = 10;
    private bool first_frame = true;

    [SerializeField] private List<Sprite> sprites;

    private void Start()
    {
        int x = Random.Range(0, sprites.Count);
        transform.GetComponent<SpriteRenderer>().sprite = sprites[x];
    }

    private void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
        
    }
    private void LateUpdate()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            if (first_frame)
            {
                first_frame = false;
            }
            else
            {
                Debug.Log("Not visible");
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().makeHappy();
        }
    }
}
