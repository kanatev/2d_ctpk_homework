using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMoving : MonoBehaviour
{
    [SerializeField] private InputActionReference move, fire, look, jump;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    private Vector2 pointerInput, movementInput;
    private Rigidbody2D rb;

    private void OnEnable() {
        fire.action.performed += PerformFire;
        jump.action.performed += PerformJump;
    }

    private void PerformFire(InputAction.CallbackContext context)
    {
        Debug.Log("fire");
    }
    private void PerformJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        rb.velocity  = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDisable() {
        fire.action.performed -= PerformFire;
    }
   

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        movementInput = move.action.ReadValue<Vector2>();
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = look.action.ReadValue<Vector2>(); 
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    void FixedUpdate()
    {
        //rb.velocity  = new Vector2(movementInput.x * moveSpeed, rb.velocity.y);
        rb.AddForce(new Vector2(movementInput.x * moveSpeed, rb.velocity.y));
    }
}
