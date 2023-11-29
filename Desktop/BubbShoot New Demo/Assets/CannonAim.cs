using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    public Transform player;
    public Camera _cam;
    public float radius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world coordinates.
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the Z position is 0 to match the object's Z position.

        // Get position relative to player
        Vector3 directionToMouse = mousePosition - player.position;

        // Ensure the object stays at the fixed distance from the center.
        Vector3 targetPosition = player.position + directionToMouse.normalized * radius;

        // Update the object's position to the target position.
        transform.position = targetPosition;

        // Keep cannon pointing at player 
        transform.rotation = Quaternion.LookRotation(Vector3.forward, directionToMouse);

    }
}
