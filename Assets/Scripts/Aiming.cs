using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float zDistance;

    public GameObject playerGameObject;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().IsDialogueIsPlaying)
        {
            return;
        }
        var mousePos = Input.mousePosition;

        // Use raycasting to get the position on the plane at zDistance from the camera.
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Plane plane = new Plane(Vector3.forward, new Vector3(transform.position.x, transform.position.y, zDistance));

        if (plane.Raycast(ray, out float hitDistance))
        {
            Vector3 targetPosition = ray.GetPoint(hitDistance);

            // Ensure the rotation only affects the Z-axis.
            Vector3 direction = targetPosition - transform.position;

            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0, 0, angle);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            // float offset = 45f;
            // transform.rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z + offset);


            // Add an offset to the Z rotation.
            float offset = 45f; // Adjust this value as needed.
            float clampedRotation = Mathf.Clamp(rotation.eulerAngles.z + offset, 220f, 360f);

            transform.rotation = Quaternion.Euler(0, 0, clampedRotation);
        }


        //
        // // Add an offset to the Z rotation.
        // float offset = 45f; // Adjust this value as needed.
        // transform.rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z + offset);
        // // Get the current Z rotation of the GameObject.
        // float currentZRotation = transform.rotation.eulerAngles.z;
        // // if (currentZRotation >= 0f && currentZRotation <= 270f)
        // // {
        // //     // Reference to the playerGameObject.
        // //     if (playerGameObject != null)
        // //     {
        // //         // Set the Y rotation to 180.
        // //         playerGameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        // //         
        // //         transform.rotation = Quaternion.Euler(0, 180, rotation.eulerAngles.z + offset);
        // //     }
        // // } else if (currentZRotation >= 270f && currentZRotation <= 360f)
        // // {
        // //     // Reference to the playerGameObject.
        // //     if (playerGameObject != null)
        // //     {
        // //         // Set the Y rotation to 0.
        // //         playerGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        // //     }
        // // }
    }
}