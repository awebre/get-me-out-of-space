using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LivesScript : MonoBehaviour
{
    public GameObject player;
    public GameObject heart;

    private List<GameObject> hearts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var lives = player.GetComponent<PlayerScript>()?.lives ?? 0;
        var currentPosition = heart.transform.position;
        var count = hearts.Count;
        while(count < lives)
        {
            if(hearts.Count == 0)
            {
                var firstPosition = heart.transform.position + new Vector3(3, 0, 0);
                hearts.Add(GameObject.Instantiate(heart, firstPosition, Quaternion.identity) as GameObject);
            } else {
                var lastPosition = hearts.Last().transform.position;
                hearts.Add(GameObject.Instantiate(heart, lastPosition + new Vector3(1, 0, 0), Quaternion.identity) as GameObject);
            }
            count++;
        }

        while(count > lives)
        {
            var lastHeart = hearts.Last();
            hearts.Remove(lastHeart);
            Destroy(lastHeart);
        }
    }
}
