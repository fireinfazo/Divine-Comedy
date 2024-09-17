using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public Mana manaScript;
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            manaScript.DrainMana(-10);
        }
    }
}
