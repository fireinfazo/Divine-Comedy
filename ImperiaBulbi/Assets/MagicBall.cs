using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    public float projectiletSpeed = 10;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var FireBall = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
            FireBall.GetComponent<Rigidbody>().velocity = ProjectileSpawnPoint.forward * projectiletSpeed;
        }
    }
}
