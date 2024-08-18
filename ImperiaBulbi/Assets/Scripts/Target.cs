using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, Damageable
{
    private float health = 100f;
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
