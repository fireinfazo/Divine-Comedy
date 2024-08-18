using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knife : MonoBehaviour
{
    [SerializeField] private ThrowableData knifeData;

    private float timeSinceLastShot;

    private void Start()
    {
        PlayerThrow.shootInput += Shoot;
        PlayerThrow.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!knifeData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        knifeData.reloading = true;

        yield return new WaitForSeconds(knifeData.reloadTime);

        knifeData.currentAmmo = knifeData.magSize;

        knifeData.reloading = false;
    }

    private bool CanShoot() => !knifeData.reloading && timeSinceLastShot > 1f / (knifeData.fireRate / 60f);
    public void Shoot()
    {
        if (knifeData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, knifeData.maxDistance))
                {
                    Damageable damageable = hitInfo.transform.GetComponent<Damageable>();
                    damageable?.TakeDamage(knifeData.damage);
                }

                knifeData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void OnGunShot()
    {

    }
}
