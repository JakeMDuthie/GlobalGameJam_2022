using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float SpeedModifier = 20.0f;
    public float JumpModifier = 50.0f;
    public float GravityDirection = 1.0f;
    public float JumpCooldownMax = 0.1f;
    public LayerMask JumpLayerMask;
    public WorldEnum world;
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private bool _canJump = false;
    private bool _warpable = false;
    private float _jumpCooldown = 0.0f;

    public int collectables = 0;


    private const string kWarpTag = "WarpZone";

    public bool Warpable
    {
        get => _warpable;
        set => _warpable = value;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        _rigidbody2D.gravityScale = GravityDirection;

        if (_jumpCooldown > 0.0f)
        {
            _jumpCooldown -= Time.deltaTime;
        }

        if (_jumpCooldown <= 0.0f && !_canJump)
        {
            if (IsGrounded())
            {
                _canJump = true;
            }
        }
    }

    public void ApplyMovement(float force)
    {
        _rigidbody2D.velocity = new Vector2(force*SpeedModifier, _rigidbody2D.velocity.y);
    }

    public void TryJump()
    {
        if (!_canJump)
        {
            return;
        }

        _canJump = false;

        _jumpCooldown = JumpCooldownMax;

        var JumpForce = (GravityDirection < 0.0f)? (-JumpModifier): JumpModifier;

        JumpForce *= _rigidbody2D.mass;
        
        _rigidbody2D.AddForce(new Vector2(0.0f, JumpForce), ForceMode2D.Impulse);
    }
    
    private bool IsGrounded()
    {
        float tolerance = 0.1f;
        float margin = 0.1f;
        var gravVector = new Vector2(0, -GravityDirection);
        var colliderSize = new Vector3(_collider2D.bounds.size.x - margin, _collider2D.bounds.size.y, _collider2D.bounds.size.z);
        var raycast = Physics2D.BoxCast(_collider2D.bounds.center, colliderSize, 0.0f, gravVector, tolerance, JumpLayerMask);

        Color rayColor = (raycast.collider) ? Color.green : Color.red;
        
        Debug.DrawRay(_collider2D.bounds.center + new Vector3(_collider2D.bounds.extents.x,0), gravVector*(_collider2D.bounds.extents.y + tolerance), rayColor);
        Debug.DrawRay(_collider2D.bounds.center - new Vector3(_collider2D.bounds.extents.x,0), gravVector*(_collider2D.bounds.extents.y + tolerance), rayColor);
        Debug.DrawRay(_collider2D.bounds.center + new Vector3(_collider2D.bounds.extents.x,((_collider2D.bounds.extents.y + tolerance)* -GravityDirection)), new Vector2(-Math.Abs(GravityDirection),0.0f)*(_collider2D.bounds.extents.y), rayColor);
        
        Debug.Log(raycast.collider);
        
        return raycast.collider != null;
    }
    
    public void getCollectable()
    {
        this.collectables++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(kWarpTag))
        {
            _warpable = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals(kWarpTag))
        {
            _warpable = false;
        }
    }
}
