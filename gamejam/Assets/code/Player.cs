using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float movement=Input.GetAxis("Horizontal");
        if (movement != 0)
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
}
