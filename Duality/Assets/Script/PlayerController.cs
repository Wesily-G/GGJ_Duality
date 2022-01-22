using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20;
    public float jumpforce;
    public LayerMask floor;
    public LayerMask white;
    public LayerMask black;
    private int lightlevel = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Trig();
    }
    void Trig()
    {
        RaycastHit2D CollectDot = Physics2D.Raycast(transform.position, transform.forward * 100, 2f, white);
        if (CollectDot && Input.GetKeyDown(KeyCode.E))
        {
            CollectDot.collider.GetComponent<SpriteRenderer>().enabled = false;
            CollectDot.collider.GetComponent<BoxCollider2D>().enabled = false;
            litup();
        }
        RaycastHit2D ReleaseDot = Physics2D.Raycast(transform.position, transform.forward * 100, 2f, black);
        if (ReleaseDot && Input.GetKeyDown(KeyCode.E))
        {
            ReleaseDot.collider.GetComponent<SpriteRenderer>().enabled = false;
            ReleaseDot.collider.GetComponent<BoxCollider2D>().enabled = false;
            litdown();
        }

    }
    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        float direction = Input.GetAxisRaw("Horizontal");
        RaycastHit2D Onground = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, floor);
        //ÒÆ¶¯
        if (movement != 0)
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        //×ªÏò
        if (direction != 0)
            transform.localScale = new Vector3(direction, 1, 1);

        //ÌøÔ¾
        if (Input.GetButtonDown("Jump") && Onground)
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }
    //freeze rotation ;gravity 3;floor;rigidbody
    void litup()
    {
        lightlevel++;
    }
    void litdown()
    {
        lightlevel--;
    }
}

