using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float speed = 120;
    [SerializeField] private float jumpForce = 120;
    [SerializeField] private ForceMode2D forceMode;
    [SerializeField] private float jumpDuration = .5f;
    [SerializeField] private Vector2 groundRadius = new Vector2(1f, .2f);
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded;
    private bool isJumping;
    private float jumpDurationValue;

    private Rigidbody2D rb;

    private void Start()
    {
        jumpDurationValue = jumpDuration;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, groundRadius, CapsuleDirection2D.Horizontal, 0, whatIsGround);
    }

    public void Move(float move, bool jump)
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (jump && !isJumping && isGrounded)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isGrounded || !jump)
        {
            isJumping = false;
            jumpDurationValue = jumpDuration;
        }
    }
}
