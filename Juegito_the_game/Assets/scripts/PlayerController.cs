using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float fireRate = 0.5f;
    private float nextFire = 0f;
    public float jumpForce;

    private Rigidbody2D rbd2d;
    private Animator animator;

    public bool facingRight;
    float facingRightFloat;

    private bool grounded;
    private bool jumping;
    private bool attacking;
    private bool crouching;
    private bool floored;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform[] groundpoints;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private float groundRadius;

    float horizontal;

    // Use this for initialization
    void Start () {
        rbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        facingRight = true;
        facingRightFloat = 1f;
        floored = false;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("LeftJoyX");
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate () {

        grounded = IsGrounded();

        HandleLayers();

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleAttacks(facingRightFloat);


        ResetValues();
	}

    void HandleMovement(float horizontal)
    {
        if (rbd2d.velocity.y < 0)
        {
            animator.SetBool("land", true);
        }

        if (!animator.GetBool("crouch") && !animator.GetBool("slide") && (grounded || airControl))
        {
            rbd2d.velocity = new Vector2(horizontal * speed, rbd2d.velocity.y);

        }

        if (grounded && jumping)
        {
            grounded = false;
            rbd2d.AddForce(new Vector2(0, jumpForce));
            animator.SetTrigger("jump");
        }

        if (crouching)
        {
            animator.SetBool("crouch", true);
        }else
        {
            animator.SetBool("crouch", false);
        }

        if (!floored)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontal));
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        if (floored && !animator.GetCurrentAnimatorStateInfo(0).IsTag("land"))
        {
            rbd2d.velocity = new Vector2(0, rbd2d.velocity.y); 
        }

    }

    void HandleAttacks(float frf)
    {
        if (attacking && !animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            animator.SetTrigger("attack");
        }
    }

    private void HandleInput()
    {
        if ( GetComponent<shoot>().shoting && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            attacking = true;
        }

        if (Input.GetAxis("LeftJoyY") == -1 && !Input.GetButton("LB"))
        {
            crouching = true;
        } else 
        {
            crouching = false;
        }

        if (Input.GetAxis("LT") != 0)
        {
            floored = true;
        }
        else 
        {
            floored = false;
        }

        if (Input.GetButtonDown("XboxA") && !crouching)
        {
            jumping = true;
        }

    }

    float Flip (float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            facingRightFloat = facingRightFloat * -1f;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
           
        }
        return facingRightFloat;
    }

    void ResetValues()
    {
        attacking = false;
        jumping = false;
    
    }

    private bool IsGrounded()
    {
        if (rbd2d.velocity.y <= 0)
        {
            foreach (Transform point in groundpoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        animator.ResetTrigger("jump");
                        animator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!grounded)
        {
            animator.SetLayerWeight(1, 1);
        } else
        {
            animator.SetLayerWeight(1, 0);
        }
    }
}
