using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for es un bucle

public class MovementPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platform;
    public Transform parentPonts;
    public float speed;
    List<Transform> point = new List<Transform>();
    int currentPoint;
    void Start()
    {
        currentPoint = 0;
        for (int i = 0; i < parentPonts.childCount; i++)
        {
            point.Add(parentPonts.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector2.MoveTowards(platform.position, point[currentPoint].position, speed * Time.deltaTime);
        if (platform.position == point[currentPoint].position)
        {
            currentPoint++;
        }
        if (currentPoint>=point.Count)
        {
            currentPoint = 0;
        }
    }
}
