using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    public float timeInAir = 0.5f;
    public float deathTimer = 10;
    public bool isDead = false;

    private bool doubleJump;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 25f;

    private enum MovementState { Idle, Jumping, Running, Falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        // Update horizontal movement
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && (IsGrounded() || !doubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (!IsGrounded())
            {
                doubleJump = true;
            }
        }

        if (!IsGrounded())
        {
            timeInAir -= Time.deltaTime;
            if (timeInAir <= 0)
            {
                Die();
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state = MovementState.Idle;

        if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else if (rb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        // Check if the player is grounded using a BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        return hit.collider != null;
    }

    private void Die()
    {
        // Implement player death logic here
        isDead = true;
    }
}
