using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMecanic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
            if (transform.parent.GetComponent<EnemyControl>().lifePoints>0)
            {
                ScoreControl.SetScore(5);
            }
            
        }
    }

}
