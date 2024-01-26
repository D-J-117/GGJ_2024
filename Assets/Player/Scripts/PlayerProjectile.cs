using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile_prefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 target = transform.position+Vector3.right*1;
            GameObject.Instantiate(projectile_prefab, target, Quaternion.identity);

        }
    }
}
