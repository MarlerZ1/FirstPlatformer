using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Animator animator;
    private AudioClip aClip;
    private AudioSource audio;
    bool stateRun = false;

    
    private bool onGround = false;
    private int jumpCd = 5;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            aClip = Resources.Load<AudioClip>("Audio/bgMusic");
            audio.loop = true;
            AudioSource.PlayClipAtPoint(aClip, transform.position );

        }
    }

    private void Update()
    {
        onGround = rb.velocity.y == 0 ? true : false;
        if (Input.GetAxis("Horizontal") != 0)
            Run();

        if (onGround && Input.GetKey(KeyCode.Space))
            Jump();

        if (rb.velocity.y == 0)
            animator.SetBool("isJump", false);

        
    }


    

    private void Run()
    {

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 0) {
            if (!audio.isPlaying && rb.velocity.y == 0)
            {
                aClip = Resources.Load<AudioClip>("Audio/Walk");
                audio.PlayOneShot(aClip);
            }
                
            
            animator.SetBool("isWalk", true);
            rb.velocity = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * speed, rb.velocity.y);
        }   
        else
        {
            audio.Stop();
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isWalk", false);
           
        }

        if (rb.velocity.x < 0.0f)
            sprite.flipX = true;
        else
            sprite.flipX = false;
        
        


    }

    private void Jump()
    {
        animator.SetBool("isWalk", false);
        animator.SetBool("isJump", true);
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += (jumpForce * Vector2.up);
        
    }

    public float getY()
    {
        return transform.position.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
          if (collision.collider.tag == "Ground")
        {
            aClip = Resources.Load<AudioClip>("Audio/Landing");
            audio.PlayOneShot(aClip);

        }
    }

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        aClip = Resources.Load<AudioClip>("Audio/Landing");
        audio.PlayOneShot(aClip);
    }
*/
  
}




