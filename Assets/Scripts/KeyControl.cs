using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(door);
        }
    }
}
