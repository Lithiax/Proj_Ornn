﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    Rigidbody2D rb2d;
    Vector2 movement;
    Animator anim;
    SpriteRenderer spr;

    public string currentOrder;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        transform.position = PlayerData.playerPosition;
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0)
            spr.flipX = true;
        if (movement.x < 0)
            spr.flipX = false;
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnDestroy()
    {
        PlayerData.playerPosition = transform.position;
    }
}
