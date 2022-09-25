using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //https://github.com/ChrisTutorials/Platformer-Character-Source-Code
    public Animator animator;
    public float groundCheckDistance = 0.1f;
    public ContactFilter2D groundCheckFilter;


    private Rigidbody2D rb;
    private Collider2D collider2d;
    private List<RaycastHit2D> groundHits = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw(AnimationParams.axisInputX);
        animator.SetFloat(AnimationParams.moveX, moveX);

        bool isMoving = !Mathf.Approximately(moveX, 0f);

        animator.SetBool(AnimationParams.isMoving, isMoving);

        // Check & Trigger for On Ground
        bool lastOnGround = animator.GetBool(AnimationParams.isOnGround);
        bool newOnGround = CheckIfOnGround();
        animator.SetBool(AnimationParams.isOnGround, newOnGround);

        if(lastOnGround == false && newOnGround == true) {
            animator.SetTrigger(AnimationParams.landedOnGround);
        }

        // Jump
        bool isJumpKeyPressed = Input.GetButtonDown(AnimationParams.jumpKeyName);

        if(isJumpKeyPressed){
            animator.SetTrigger(AnimationParams.JumpTriggerName);
        } else {
            animator.ResetTrigger(AnimationParams.JumpTriggerName);
        }
    }

    void FixedUpdate() {
       
        float forceX = animator.GetFloat(AnimationParams.forceX);
        
        if (forceX != 0) rb.AddForce(new Vector2(forceX, 0) * Time.deltaTime);

        float impulseX = animator.GetFloat(AnimationParams.impulseX);
        float impulseY = animator.GetFloat(AnimationParams.impulseY);

        if (impulseY != 0 || impulseX != 0){
            float xDirection = Mathf.Sign(transform.localScale.x);
            Vector2 pulseVector = new Vector2(xDirection * impulseX, impulseY);

            rb.AddForce(new Vector2(0, impulseY), ForceMode2D.Impulse);
            animator.SetFloat(AnimationParams.impulseX, 0);
            animator.SetFloat(AnimationParams.impulseY, 0);
        }
        
        animator.SetFloat(AnimationParams.velocityY, rb.velocity.y);

        bool isStopVelocity = animator.GetBool(AnimationParams.stopVelocity);

        if(isStopVelocity){
            rb.velocity = Vector2.zero;
            animator.SetBool(AnimationParams.stopVelocity, false);
        }



        //https://youtu.be/aTB-5aE0POw?list=PLyH-qXFkNSxnyOJxh-2YoaEr7BDMLGyz0&t=3388
    }

    bool CheckIfOnGround() {
        collider2d.Cast(Vector2.down, groundCheckFilter, groundHits, groundCheckDistance);

        if(groundHits.Count > 0) {
            return true;
        } else {
            return false;
        }
    }
}
