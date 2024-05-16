using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float zDistance;
    public GameObject playerGameObject;
    public Transform targetTransform;
    public LayerMask mouseAimmask;

    private Camera _mainCamera;


    // Use this for initialization
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().IsDialogueIsPlaying)
        {
            return;
        }

        //transform.LookAt(targetTransform);

        var mousePos = Input.mousePosition;

        Ray ray = _mainCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimmask))
        {
            targetTransform.position = hit.point;

            // Use LookAt to get the direction to the target
            Vector3 direction = targetTransform.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Create a rotation that only affects the Z axis
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            // Apply the rotation to the transform
            transform.rotation = rotation;
        }
    }

    private void OnAnimatorIK()
    {
    }
}