﻿using Cinemachine;
using UnityEngine;

public sealed class CameraPositioner : MonoBehaviour, IInitializable
{
    private const float Multiplier = 6f / 10f;
    private readonly Vector3 _offset = new(-10 * Multiplier, 10 * Multiplier, 10 * Multiplier);
    private readonly Vector3 _rotation = new(30, 135, 0);

    private GameManager _gameManager;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.CinemachineVirtualCamera.Follow = transform;
        _gameManager.CinemachineVirtualCamera.transform.rotation = Quaternion.Euler(_rotation);

        var transposer = (CinemachineTransposer)_gameManager.CinemachineVirtualCamera.GetCinemachineComponent(
            CinemachineCore.Stage.Body
        );

        transposer.m_FollowOffset = _offset;

        _gameManager.GameDataManager.nextCubePosition.actions +=
            pos => transform.position = pos;
    }
}