using UnityEngine;

public class DashingController : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
    }

    void StartDash()
    {
        float dashDirection = 0f;

        // Determine dash direction based on current input
        if (Input.GetKey(KeyCode.A))
        {
            dashDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dashDirection = 1f;
        }
        else
        {
            // If neither A nor D is pressed, disable the dash
            isDashing = false;
            return;
        }

        isDashing = true;
        dashTimeLeft = dashTime;
        lastDashTime = Time.time;

        // Add any visual or sound effects for the dash initiation here

        // Adjust the player's scale based on the dash direction if needed
        Vector3 newScale = transform.localScale;
        newScale.x = dashDirection;
        transform.localScale = newScale;
    }

    void Dash()
    {
        if (dashTimeLeft > 0)
        {
            float dashDistanceThisFrame = dashDistance * Time.deltaTime / dashTime;
            float dashDirection = transform.localScale.x; // Use the stored scale for direction
            transform.Translate(Vector3.right * dashDirection * dashDistanceThisFrame);
            dashTimeLeft -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
            // Add any visual or sound effects for the dash completion here
        }
    }
}