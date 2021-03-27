using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * speed;
        Debug.DrawRay(position, direction, Color.green);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
