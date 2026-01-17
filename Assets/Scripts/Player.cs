using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _jumpEndTime = 0.5f;
    [SerializeField] private float _jumpVelocity = 5;
    [SerializeField] private float _jumpDuration = 0.5f;

    void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float bottomY = spriteRenderer.bounds.extents.y;
        Vector2 origin =  new Vector2(transform.position.x, transform.position.y - bottomY);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var vertical = rb.velocity.y;

        if (Input.GetButtonDown("Fire1"))
        {
            _jumpEndTime = Time.time + _jumpDuration;
        }
        if (Input.GetButton("Fire1") && _jumpEndTime > Time.time)
        {
            vertical = _jumpVelocity;
        }
        rb.velocity = new Vector2(horizontal, vertical);
    }
}
// Left off at lesson 15