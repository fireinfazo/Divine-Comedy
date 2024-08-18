using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sword : MonoBehaviour
{
    [SerializeField] private SwordData SwordData;

    private float timeSinceLastAttack;

    private void Start()
    {
        PlayerAttack.attackInput += Attack;
    }

    private bool CanAttack() => timeSinceLastAttack > 1f / (SwordData.fireRate / 60f);
    public void Attack()
    {
        
            if (CanAttack())
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, SwordData.maxDistance))
                {
                    Damageable damageable = hitInfo.transform.GetComponent<Damageable>();
                    damageable?.TakeDamage(SwordData.damage);
                }
                timeSinceLastAttack = 0;
                OnGunShot();
            }
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }

    private void OnGunShot()
    {

    }
}
