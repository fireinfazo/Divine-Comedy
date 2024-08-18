using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static Action attackInput;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            attackInput?.Invoke();
        }
    }
}

