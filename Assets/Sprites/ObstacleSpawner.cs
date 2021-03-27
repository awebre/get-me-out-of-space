using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Object = System.Object;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    private List<TimedGameObject> _visibleObjects = new List<TimedGameObject>();
    private float _timer;
    private float _lastRender;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        var index = Random.Range(0, objects.Count());
        var asteroidSprite = objects[index];
        var currentPosition = asteroidSprite.transform.position;
        if (_timer - _lastRender > Random.Range(2f, 4f))
        {
            var tmpObj = GameObject.Instantiate(asteroidSprite, currentPosition, Quaternion.identity) as GameObject;
            tmpObj.transform.position = new Vector3(10f, GetYFromRange(GetRandomRegion()), 0);
            _visibleObjects.Add(new TimedGameObject(tmpObj, _timer));
            _lastRender = _timer;
        }

        var destroy = _visibleObjects.Where(o => _timer - o.CreatedTimestamp > 15);
        foreach(var obj in destroy)
        {
            Destroy(obj.GameObject);
            _visibleObjects.Remove(obj);
        }
    }

    public Region GetRandomRegion()
    {
        var range = Random.Range(0f, 1f);
        return range switch
        {
            var r when r < 0.75f => Region.Bottom,
            var r when 0.75 <= r && r <= 0.90f => Region.Middle,
            var r when 0.90f < r => Region.Top,
            _ => Region.Bottom
        };
    }

    public float GetYFromRange(Region region)
    {
        switch (region)
        {
            case Region.Top:
                return Random.Range(1.5f, 4f);
            case Region.Middle:
                return Random.Range(-0.5f, 1.5f);
            case Region.Bottom:
            default:
                return Random.Range(-3.5f, -0.5f);
        }
    }
}

public enum Region
{
    Top,
    Middle,
    Bottom
}

public class TimedGameObject
{
    public TimedGameObject(GameObject gameObject, float createdTimestamp)
    {
        GameObject = gameObject;
        CreatedTimestamp = createdTimestamp;
    }
    public GameObject GameObject { get; }

    public float CreatedTimestamp { get; }
}
