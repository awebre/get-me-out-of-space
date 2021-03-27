using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float groundCheckDistance;
    public float jetpackMeterMax;
    public float jetpackCost;
    public float jetpackRefillSpeed;
    public GameObject jetpackBar;
    private float jetpackMeter;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        jetpackMeter = jetpackMeterMax;
    }

    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Jump()
    {
        var bar = jetpackBar.GetComponent<Image>();

        if (Input.GetButtonDown("Jump") && jetpackMeter >= jetpackCost)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jetpackMeter -= jetpackCost;
        }

        if(jetpackMeter < jetpackMeterMax)
        {
            jetpackMeter += jetpackRefillSpeed;
        }

        bar.color = jetpackMeter >= jetpackCost ? Color.yellow : Color.red;
        bar.fillAmount = jetpackMeter / jetpackMeterMax;
    }

    void Squish()
    {

    }
}
