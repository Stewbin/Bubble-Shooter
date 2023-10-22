using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float lifespan;  // The time (in seconds) before the projectile is destroyed.

    void Update()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    protected void changeLifeSpan(int num)
    {
        lifespan = num;
    }
}
