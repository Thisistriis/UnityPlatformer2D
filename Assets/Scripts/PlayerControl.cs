
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//else contrario if
//!=  distinto

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D rb;
    
    public float speed;
    public float jumpForce;
    public float dashForce;
    public Transform[] groundPoints;
    public bool isGrounded;
    public LayerMask groundMask;
    public int currentJumps;
    public int totalJumps;
    public Transform shootParent;
    public GameObject bullet;

    Animator Animator;
    private float Horizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("Walking", Horizontal != 0.0f);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal")!=0)
        {
            float dir = Input.GetAxisRaw("Horizontal") == 1 ? 0 : 180;
            transform.localEulerAngles = new Vector2(0, dir);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, shootParent.GetChild(0).position, shootParent.GetChild(0).rotation);
            Destroy(newBullet, 3f);
            Animator.SetTrigger("Shoot");
            AudioManager.instance.Play("Shoot");
        }
        isGrounded = Physics2D.OverlapArea(groundPoints[0].position, groundPoints[1].position, groundMask);
        
        if (isGrounded == true)
        {
            Animator.SetBool("OnGround", isGrounded);
            if (currentJumps != 0) 
            {
                currentJumps = 0;
            }
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce);
                currentJumps++;
                Animator.SetTrigger("Jump");
                AudioManager.instance.Play("Jump");
            }
        }
        else
        {
            Animator.SetBool("OnGround", isGrounded);
            if (Input.GetButtonDown("Jump") && currentJumps < totalJumps)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce);
                currentJumps++;
                Animator.SetTrigger("Jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (rb.velocity.x > 0.0f)
            {
                //rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.right * dashForce);
                Animator.SetTrigger("Dash");
                AudioManager.instance.Play("Dash");
            }
            if (rb.velocity.x < 0.0f)
            {
                //rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.left * dashForce);
                Animator.SetTrigger("Dash");
                AudioManager.instance.Play("Dash");
            }
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            Animator.SetTrigger("Dead");
            AudioManager.instance.Play("DeadPlayer");
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MovePlt")
        {
            transform.SetParent(collision.transform);

        }
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreControl.SetScore(1);
            AudioManager.instance.Play("Coin");
        }
        if (collision.tag == "Diamond")
        {
            Destroy(collision.gameObject);
            
            AudioManager.instance.Play("Diamond");
            Diamond();
        }
        if (collision.tag == "GetDmg")
        {
           Animator.SetTrigger("Hurt");
            AudioManager.instance.Play("Hurt");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovePlt")
        {
            transform.SetParent(null);
        }
    }

    public void DeathMushie()
    {
        SceneManager.LoadScene(3);
    }

    public void Diamond()
    {
        SceneManager.LoadScene(4);
    }


    public void DeathAnimationController()
    {
        Animator.SetTrigger("Dead");
        AudioManager.instance.Play("DeadPlayer");
    }
}
