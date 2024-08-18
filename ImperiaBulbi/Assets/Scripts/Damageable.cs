using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    public void Damage(float damage);
    void TakeDamage(float damage);
}