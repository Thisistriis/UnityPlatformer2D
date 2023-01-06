using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDmg : MonoBehaviour
{
    public string[] tags;
    public bool instakill;
    public Vector2Int randomDmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetDmgCollider(collision.tag, collision.gameObject);
    }

   
    public void SetDmgCollider(string tag, GameObject other)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (tags[i] == tag)
            {
                int damage = Random.Range(randomDmg.x, randomDmg.y);
                if (instakill == true)
                {
                    damage = 9999999;
                }
                if (other.GetComponent<LifeController>()!=null)
                {
                    other.GetComponent<LifeController>().SetDamage(damage);
                }
                return;
            }
        }
    }

        
}
