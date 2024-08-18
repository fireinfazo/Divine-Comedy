using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensetivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float smoothedMousePos;

    private float currentLookingSpot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePos *= sensetivity * sensetivity;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        currentLookingSpot += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingSpot, transform.up);
    }
}