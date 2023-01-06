using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    public LayerMask colMask;
    public int lifePoints;
    Rigidbody2D rb;
    int dir;
    public Transform detectPosition;
    public bool TypeOfDetection;
    void Start()
    {
        dir = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        Collider2D detector = Physics2D.OverlapCircle(detectPosition.transform.position, 0.2f, colMask);
        if (detector != null)
        {
            dir *= -1;
            transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            lifePoints--;
            if (lifePoints<=0)
            {
                Destroy(gameObject);
                ScoreControl.SetScore(5);
            }
        }
    }
}
