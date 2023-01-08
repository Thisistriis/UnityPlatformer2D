using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KeyControl : MonoBehaviour
{

    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.Play("Key");
            Destroy(gameObject);
            Destroy(door);

        }
    }
}
