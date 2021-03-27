using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingImage : MonoBehaviour
{
    public GameObject backgroundImage;
    public float timeInterval;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeInterval)
        {
            Instantiate(backgroundImage);
            timer = 0;
        }
    }
}
