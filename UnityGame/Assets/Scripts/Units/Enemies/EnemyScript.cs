using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float moveSpeed;
    public float comfyDistance;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = GameManager.Instance.player.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(movement.x) > comfyDistance && Mathf.Abs(movement.y) > comfyDistance)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
            GameManager.Instance.enemyCount--;
            GameManager.Instance.score++;
            GameManager.Instance.xp+=5;
        }
        
            
    }
}
