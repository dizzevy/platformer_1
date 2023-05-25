using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;
    private float health = 2f;

    [Header("Player Movement Setting")]
    [Range(0, 4f)] public float speed = 1f;
    [Range(0,15f)] public float jumpForce = 8f;

    [Space]
    [Header("Ground Checker Setting")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0,5f)] public float checkGroundRadius = 0.3f;

    [Header("Player Animation Settings")]
    public Animator animator;
    


    



    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up *jumpForce, ForceMode2D.Impulse);
        }
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }

        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

        if(isGrounded == false)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        if(health == 0)
        {
            Destroy(this.gameObject, 0.1f);
        }
    }

    void FixedUpdate() 
    {
       Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y); 
       rb.velocity = targetVelocity;
       CheckGround();
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        if(colliders.Length > 2)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy"))
        {
            takeDamage();
        }
    }

    private void takeDamage(){
        health --; 
        Debug.Log("da");
    }

}
