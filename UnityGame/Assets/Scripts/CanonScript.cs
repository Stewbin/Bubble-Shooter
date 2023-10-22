using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public float lifespan = 2.0f;  // The time (in seconds) before the projectile is destroyed.

    void Update()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
