using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSet : MonoBehaviour
{
    private CinemachineVirtualCamera _playerCamera;

    private void Awake()
    {
        _playerCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        _playerCamera.Follow = GameManager.Instance.Player.transform;
    }
}
