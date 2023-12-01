using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Smooth Camera follow script unity
    private Vector3 offset;
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed = 0.125f;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed);
    }
}
