using UnityEngine;

using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Sword", menuName = "Weapon")]
public class SwordData : ScriptableObject
{
    [Header("Info")]

    public new string name;

    [Header("Attacking")]

    public float damage;
    public float maxDistance;
    public float fireRate;
}