using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool IsBattling => battleCamera.gameObject.activeSelf;

    public Camera playerCamera;
    public Camera battleCamera;
    public VariableJoystick joiStick;

    private void Start()
    {
        playerCamera.gameObject.SetActive(true);
        battleCamera.gameObject.SetActive(false);
    }


    public void SwitchToBattle()
    {
        joiStick.gameObject.SetActive(false);
        battleCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
    }

    public void SwitchToPlayer()
    {
        joiStick.gameObject.SetActive(true);
        battleCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
    }
}