using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMagicBall : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    public float projectileSpeed = 1;
    public int numberOfFireballs = 7;
    public float damage = 3f;
    public float fireRate = 1f;
    private float nextFireTime;
    public Mana manaScript;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Time.time > nextFireTime && manaScript.mana >= 10)
        {
            nextFireTime = Time.time + fireRate;
            manaScript.DrainMana(10 * numberOfFireballs);

            for (int i = 0; i < numberOfFireballs; i++)
            {
                GameObject fireBall = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
                fireBall.GetComponent<Rigidbody>().velocity = ProjectileSpawnPoint.forward * projectileSpeed;
                fireBall.GetComponent<SmallFireBalls>().damage = damage;
            }
        }
    }
}