using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke();
        }
    }
}