using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
    [SerializeField] private LayerMask[] grounds;
    public float Speed = 40f;
    public bool grounded;
    private float LR;
    private bool jump = false;
    public float groundCheckRadius =.2f;
    private Rigidbody2D rb;
    private Vector3 Velocity = Vector3.zero;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LR = Input.GetAxisRaw("Horizontal") * Speed;
        jump = Input.GetKeyDown( KeyCode.Space);
        //Move();
    }

    private void Move()
    {
        if (player.UsingTool)
        {
            return;
        }
        Vector3 newVelocity = new Vector2((LR * Time.fixedDeltaTime) * 10f, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, newVelocity, ref Velocity, MovementSmoothing);

        if (grounded && jump)
        {
            grounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        Move();
    }

    private void GroundCheck()
    {
        foreach (LayerMask layerMask in grounds)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius, layerMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    grounded = true;
                }
            }
        }
        
    }
}
