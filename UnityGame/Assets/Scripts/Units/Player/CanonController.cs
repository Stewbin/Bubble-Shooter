using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public Camera _cam;
    private float fixedDistance = 1.0f;  // The fixed distance from the center.
    public Transform player;         // The center point around which the object will rotate.
    public GameObject canon;
    public float canonSpeed;
    private Vector2 canonDirection;

    private void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        // Stops the code from running if the game is paused.
        if (GameManager.Instance.State == GameManager.GameState.Paused)
            return;

        // Get the mouse position in world coordinates.
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the Z position is 0 to match the object's Z position.

        // Calculate the direction vector from the center to the mouse.
        Vector3 directionToMouse = mousePosition - player.position;

        // Ensure the object stays at the fixed distance from the center.
        Vector3 targetPosition = player.position + directionToMouse.normalized * fixedDistance;

        // Update the object's position to the target position.
        transform.position = targetPosition;

        // Calculate the rotation while keeping the Y-axis (yaw) rotation fixed.
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToMouse);
        transform.rotation = targetRotation;

        
        canonDirection = mousePosition - transform.position;
        if(Input.GetMouseButtonDown(0))
        {
            //Instantiate a canon ball
            GameObject canonBall = Instantiate(canon, transform.position, Quaternion.identity);
            //Apply force
            Rigidbody2D rb = canonBall.GetComponent<Rigidbody2D>();
            rb.AddForce(canonSpeed * canonDirection.normalized, ForceMode2D.Force);
        }


    }
}
