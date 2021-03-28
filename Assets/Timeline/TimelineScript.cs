using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineScript : MonoBehaviour
{
    public float timeLimit;
    public float currentTime;
    public Vector3 endPosition;
    public GameObject playerIcon;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = playerIcon.transform.position;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        playerIcon.transform.position = Vector2.Lerp(startPosition, endPosition, currentTime / timeLimit);

        if(currentTime > timeLimit)
        {
            SceneManager.LoadScene(sceneName: "Finish");
        }
    }
}
