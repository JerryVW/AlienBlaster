using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _jumpEndTime = 0.5f;
    [SerializeField] float _horizontalVelocity = 3;
    [SerializeField] float _jumpVelocity = 5;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] Sprite _jumpSprite;
    public bool IsGrounded;
    SpriteRenderer _spriteRenderer;
    Sprite _defaultSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }

    void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 origin =  new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 origin =  new Vector2(transform.position.x, transform.position.y - _spriteRenderer.bounds.extents.y);
        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        if (hit.collider)
        {
            IsGrounded = true;
            _spriteRenderer.sprite = _defaultSprite;
            
        }
        else
        {
            IsGrounded = false;
            _spriteRenderer.sprite = _jumpSprite;
        }

        var horizontal = Input.GetAxis("Horizontal");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var vertical = rb.velocity.y;

        if (Input.GetButtonDown("Fire1") && IsGrounded)
        {
            _jumpEndTime = Time.time + _jumpDuration;
        }
        if (Input.GetButton("Fire1") && _jumpEndTime > Time.time)
        {
            vertical = _jumpVelocity;
        }

        horizontal *= _horizontalVelocity;
        rb.velocity = new Vector2(horizontal, vertical);
    }
}
// Left off at lesson 15