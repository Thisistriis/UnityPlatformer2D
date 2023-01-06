using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector2 offset;
    public Transform[] limitX;
    public Transform[] limitY;
    
    void Update()
    {
        if (target == null || target.parent == null)
        {
            return;
        }
        movement();
    }
    private void FixedUpdate()
    {
        if (target == null || target.parent != null)
        {
            return;
        }
        movement();
    }
    public void movement()
    {
        Vector3 finalpos = (Vector2)target.position + offset;
        finalpos.z = -10;
        if (finalpos.x < limitX[0].position.x)
        {
            finalpos.x = limitX[0].position.x;
        }
        if (finalpos.y < limitY[0].position.y)
        {
            finalpos.y = limitY[0].position.y;
        }
        if (finalpos.x > limitX[1].position.x)
        {
            finalpos.x = limitX[1].position.x;
        }
        if (finalpos.y > limitY[1].position.y)
        {
            finalpos.y = limitY[1].position.y;
        }




        transform.position = Vector3.Lerp(transform.position, finalpos, speed * Time.deltaTime);

    }
}
