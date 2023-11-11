using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform player; // Reference to the player character.
    public Camera mainCamera; // Reference to the main camera.

    public float rotationX; // The rotation of the weapon around the X axis.
    public float rotationY; // The rotation of the weapon around the Y axis.
    public float rotationZ; // The rotation of the weapon around the Z axis.

    Vector3 position; // The original position of the weapon.

    Transform weaponTransform; // Reference to the weapon's transform.

    private Quaternion targetRotation;

    public GameObject weapon;
    
    private void Awake()
    {
        position = transform.position; // Store the original position of the weapon.
        Debug.Log("position: " + position);
        Debug.Log(weapon.transform.position);
    }

    private void Update()
    {
        Vector3 weaponRotation = transform.rotation.eulerAngles;

        rotationX = weaponRotation.x;
        rotationY = weaponRotation.y;
        rotationZ = weaponRotation.z;


        // Get the mouse position in screen coordinates.
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Adjust the Z position to be in front of the camera.

        // Convert the screen position to world position.
        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calculate the direction to the mouse pointer.
        Vector3 direction = (targetPosition - transform.position) * -1;
        direction.z = 0; // Ensure the weapon stays in the same Z position.

        // Rotate the weapon to point in the direction of the mouse pointer.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Check if the Z rotation is between 90 and 270 degrees.
        if (newRotation.eulerAngles.z >= 90 && newRotation.eulerAngles.z <= 270)
        {
            // Create a new rotation with Y set to 180 degrees.
            Quaternion newYRotation = Quaternion.Euler(180, 0, 0);

            // Combine the new Y rotation with the existing Z rotation.
            newRotation *= newYRotation;
        }
        

        transform.rotation = newRotation;
        //check rotation z between 90 to 270, change the transform rotation Y to 180

        //log debug the rotation xyz
        // Debug.Log("rotationX: " + rotationX);
        // Debug.Log("rotationY: " + rotationY);
        // Debug.Log("rotationZ: " + rotationZ);
    }
}