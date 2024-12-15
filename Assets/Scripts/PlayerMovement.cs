using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;

    Collider2D bodyColl;
    Collider2D feetColl;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] Vector2 deathKick;

    bool isGrounded;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump()
    {
        if (isGrounded)
        {
            //rb.AddForce(Vector2.up * jumpSpeed);
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        if (moveInput.x != 0)
        {
           transform.localScale = new Vector2(moveInput.x, transform.localScale.y);
        } 
        
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }
}