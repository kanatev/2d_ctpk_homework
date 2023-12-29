using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMoving : MonoBehaviour
{
    [SerializeField] private InputActionReference move, fire, look;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 pointerInput, movementInput;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform sprite;
    private bool isFacingLeft = true;
    private bool isAttacking;
    private bool isMoving;
    Vector2 previousMovementDirection;

    public void OnMoving(InputAction.CallbackContext context)
    {
        // move character
        movementInput = move.action.ReadValue<Vector2>();

        // start moving animation on hold 'move buttons', stop moving animation on release 'move buttons'
        switch (context.phase)
        {
            case InputActionPhase.Started:
                // Debug.Log(context.interaction + " - Started");
                if(!isMoving)
                {
                    isMoving = true;
                    animator.SetBool("IsMoving", true);
                }
                break;
            case InputActionPhase.Canceled:
                // Debug.Log(context.interaction + " - Canceled");
                if(isMoving)
                {
                    isMoving = false;
                    animator.SetBool("IsMoving", false);
                }
                break;
        }
    }

    void Flip()
    {
        // flip characater if changed direction
        if (movementInput.x == 1 && isFacingLeft)
        {
            sprite.localScale  = new Vector2(-sprite.localScale.x, sprite.localScale.y);
            isFacingLeft = false;
            previousMovementDirection = movementInput;
        }
        else if (movementInput.x == -1 && !isFacingLeft)
        {
            sprite.localScale = new Vector2(-sprite.localScale.x, sprite.localScale.y);
            isFacingLeft = true;
            previousMovementDirection = movementInput;
        }
    }

    public void OnAttacking(InputAction.CallbackContext context)
    {
        if (!isAttacking)
        {
            // Debug.Log("fire");
            animator.SetBool("IsAttacking", true);
            isAttacking = true;
            Invoke(nameof(EndOfAttack), 1);
        }
    }
     void EndOfAttack()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.transform.GetChild(0);
        animator = sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {     
        if (isMoving && !isAttacking)
        {
            rb.velocity  = new Vector2(movementInput.x * moveSpeed, rb.velocity.y) * Time.deltaTime;

            if (movementInput != previousMovementDirection)
            {
                Flip();
            }
        }
    }
}
