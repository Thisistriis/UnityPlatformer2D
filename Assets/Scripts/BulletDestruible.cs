using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruible : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifePoints;
    public bool canDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (canDestroy==true)
            {
                lifePoints--;
                if (lifePoints <= 0)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
