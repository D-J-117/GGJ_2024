using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }
}
