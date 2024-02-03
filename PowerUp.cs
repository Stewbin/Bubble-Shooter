using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PlayerController player;
    public Boolean showing;
    public Collider2D hitbox;
    public Renderer render;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        showing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(showing) {
            render.enabled = true;
            hitbox.enabled = true;
        } else {
            render.enabled = false;
            hitbox.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            showing = false;
            if(type == 0) {
                player.speed *= 5;
            }
        }
    }
}
