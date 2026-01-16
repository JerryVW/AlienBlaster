using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }
}
// Left off at lesson 11