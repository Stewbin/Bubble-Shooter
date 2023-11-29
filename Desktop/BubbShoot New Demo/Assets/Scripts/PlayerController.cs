using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement; //Direction of movement vector. Has 0s and 1s

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
