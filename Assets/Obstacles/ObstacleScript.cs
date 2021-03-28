using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject player;
    private float _timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1.5f * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider coll)
    {
        var player = coll.GetComponent<PlayerScript>();
        if(player != null && player.invincibilityTimer > 0)
        {
            player.lives--;
            player.invincibilityTimer = 15f;
        }
    }
}
