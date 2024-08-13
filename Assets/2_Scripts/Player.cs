using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;

    private Animator anim;
    private Rigidbody2D rigd;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    internal void Init()
    {
        throw new NotImplementedException();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            rigd.AddForce(Vector2.one*JumpPower);
            JumpPower = 0;
            anim.SetInteger("StateID", 2);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpPower += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);
    }
    
}
