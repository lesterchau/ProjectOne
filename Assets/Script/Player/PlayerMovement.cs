﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float costPerSecond;

    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Transform firePointHolder;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        PlayerStat stat = GetComponent<PlayerStat>();

        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.sqrMagnitude != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            stat.degenerate = costPerSecond;
        }
        else
            stat.degenerate = 0;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - rb.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePointHolder.GetComponent<Rigidbody2D>().rotation = angle;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void GetSpeedAndCost(float speed, float cost)
    {
        moveSpeed = speed;
        costPerSecond = cost;
    }

}
