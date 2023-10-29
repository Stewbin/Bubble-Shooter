using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonMovement : MonoBehaviour
{
    public Transform self;
    private float fixedDistance = 0.7f;
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    private float timer = 0.0f;
    public GameObject canon;
    public float canonSpeed;
    private Vector2 canonDirection;

    // Update is called once per frame
    void Update()
    {

        // Calculate the direction vector from the center to the mouse.
        Vector3 directionToPlayer = GameManager.Instance.player.position - self.position;

        // Ensure the object stays at the fixed distance from the center.
        Vector3 targetPosition = self.position + directionToPlayer.normalized * fixedDistance;

        // Update the object's position to the target position.
        transform.position = targetPosition;

        // Calculate the rotation while keeping the Y-axis (yaw) rotation fixed.
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
        transform.rotation = targetRotation;

        canonDirection = GameManager.Instance.player.position - transform.position;
        if (timer >= spawnInterval)
        {
            //Instantiate a canon ball
            GameObject canonBall = Instantiate(canon, transform.position, Quaternion.identity);
            //Apply force
            Rigidbody2D rb = canonBall.GetComponent<Rigidbody2D>();
            rb.AddForce(canonSpeed * canonDirection.normalized, ForceMode2D.Force);
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }
}
