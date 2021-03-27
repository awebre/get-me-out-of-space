using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineScript : MonoBehaviour
{
    public float timeLimit;
    public float currentTime;
    public Vector2 endPosition;
    public GameObject playerIcon;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = playerIcon.transform.position;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        playerIcon.transform.position = Vector2.Lerp(startPosition, endPosition, currentTime/timeLimit);
    }
}
