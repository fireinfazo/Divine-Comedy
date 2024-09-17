using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    public float projectileSpeed = 100;
    public float fireRate = 1f;
    private float nextFireTime;
    public Mana manaScript;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Time.time > nextFireTime && manaScript.mana >= 10)
        {
            nextFireTime = Time.time + fireRate;
            manaScript.DrainMana(10);
            var fireBall = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
            fireBall.GetComponent<Rigidbody>().velocity = ProjectileSpawnPoint.forward * projectileSpeed;
        }
    }
}
