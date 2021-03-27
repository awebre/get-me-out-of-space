using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScriptTest : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        transform.Translate(new Vector3(-moveSpeed, 0, 0));
    }
}
