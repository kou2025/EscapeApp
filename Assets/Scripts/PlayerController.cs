using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 lastDirection;

    public Sprite backIdleSprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        lastDirection = Vector2.down;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal,vertical).normalized;

        rb.MovePosition(rb.position + movement * 3.0f * Time.deltaTime); 

        // animator.SetBool("isWalking", movement.magnitude > 0);

        if(movement.magnitude > 0){

            lastDirection = movement;

            if(horizontal > 0){
                animator.Play("RightWalk",0);
            }else if(horizontal < 0){
                animator.Play("LeftWalk",0);
            }else if(vertical < 0){
                animator.Play("FrontWalk",0);
            }else if(vertical > 0){
                animator.Play("BackWalk",0);
            }

        }else{
            if(lastDirection.x > 0)animator.Play("RightIdle",0);
            else if(lastDirection.x < 0)animator.Play("LeftIdle",0);
            else if(lastDirection.y < 0)animator.Play("FrontIdle",0);
            else if(lastDirection.y > 0)animator.Play("BackIdle",0);


        }
        // if(animator.GetCurrentAnimatorStateInfo(0).IsName("BackWalk") &&
        //     animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
        //         spriteRenderer.sprite = backIdleSprite;
        //     }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall")){
        }
        
    }
}
