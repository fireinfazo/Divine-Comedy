using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrowableKnife", menuName = "Throwable")]
public class ThrowableData : ScriptableObject
{
    [Header("Info")]
    public new string name;

    [Header("Throwing")]

    public float damage;
    public float maxDistance;

    [Header("Reloading")]

    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
}