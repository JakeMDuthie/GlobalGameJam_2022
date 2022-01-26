using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float SpeedModifier = 20.0f;
    public float JumpModifier = 50.0f;
    public float GravityDirection = 1.0f;
    
    private Rigidbody2D _rigidbody2D;
    private bool _canJump = false;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _rigidbody2D.gravityScale = GravityDirection;
    }

    public void ApplyMovement(float force)
    {
        _rigidbody2D.velocity = new Vector2(force*SpeedModifier, _rigidbody2D.velocity.y);
    }

    public void TryJump()
    {
        /*if (!_canJump)
        {
            return;
        }*/

        var JumpForce = (GravityDirection < 0.0f)? (-JumpModifier): JumpModifier;

        JumpForce *= _rigidbody2D.mass;
        
        _rigidbody2D.AddForce(new Vector2(0.0f, JumpForce), ForceMode2D.Impulse);
    }
}
