using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile_prefab;
    [SerializeField] private List<AudioClip> laugh_sounds;
    [SerializeField] private AudioSource audio_source;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 target = transform.position+Vector3.right*1;
            GameObject.Instantiate(projectile_prefab, target, Quaternion.identity);
            int x = Random.Range(0, laugh_sounds.Count);
            audio_source.PlayOneShot(laugh_sounds[x]);

        }
    }
}
