using System;
using Mono.Cecil.Cil;
using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    public float PlayerSpeed;
    private Vector2 moveInput;
    private Animator anim;
    public bool isGrounded;
    public bool canJump = true;
    public float jumpValue = 10.0f;
    public TMP_Text jumpPower;

    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        jumpPower.text = $"Strenght: {jumpValue}";

        isGrounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, -transform.up, 0.1f, groundLayer);

        if (Math.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            jumpValue += 0.2f;
        }

        if (jumpValue >= 20f && isGrounded)
        {
            float tempx = moveInput.x * PlayerSpeed;
            float tempz = jumpValue;
            rb.linearVelocity = new Vector2(tempx, tempz);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(moveInput.x * PlayerSpeed, jumpValue);
                jumpValue = 10.0f;
            }
            canJump = true;
        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 10.0f;
    }
    private void MovePlayer()
    {
        moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * PlayerSpeed, rb.linearVelocity.y);

        if (moveInput.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (moveInput.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }



}
