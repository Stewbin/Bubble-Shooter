using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonScript1 : CanonScript 
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile" || collision.gameObject.tag == "Character")
            Destroy(gameObject);

    }
}
