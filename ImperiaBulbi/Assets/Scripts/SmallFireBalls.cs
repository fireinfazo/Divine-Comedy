using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireBalls : MonoBehaviour
{
    public float damage = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
