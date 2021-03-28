using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float _timer;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector3.zero;
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var player = coll.GetComponent<PlayerScript>();
        if(player != null && player.invincibilityTimer == 0)
        {
            player.lives--;
            player.invincibilityTimer = 2f;
        }
    }
}
