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

    private void FixedUpdate()
    {
        transform.position = transform.position + direction * speed * Time.fixedDeltaTime;
        
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
                Destroy(gameObject);
            }
        }
    }
}
