using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesControl : MonoBehaviour
{
    public Transform spikes;
    public Transform parentPoints;
    public float speed;
    public float timer;
    public float cooldown;
    int currentPoint;
    List<Transform> points = new List<Transform>();
    void Start()
    {
        for (int i = 0; i < parentPoints.childCount; i++)
        {
            points.Add(parentPoints.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        spikes.position = Vector2.MoveTowards(spikes.position, points[currentPoint].position, speed * Time.deltaTime);
        if (spikes.position == points[currentPoint].position)
        {
            timer += Time.deltaTime;
            if (timer>= cooldown)
            {
                currentPoint++;
                timer = 0;
                if (currentPoint>=points.Count)
                {
                    currentPoint = 0;
                }
            }
        }
    }
}
