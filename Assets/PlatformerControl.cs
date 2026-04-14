using UnityEngine;
using UnityEngine.InputSystem;


public class PlatformerControl : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    bool onFloor = false;
    bool isFacingRight = true;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", rb.linearVelocity.x != 0);
        animator.SetBool("isGround", onFloor);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        rb.linearVelocity = new Vector2(input.x * speed, rb.linearVelocity.y);

        if (input.x < 0 && isFacingRight)
        {
            spriteRenderer.flipX = true;
            isFacingRight = false;
        }
        else if (input.x > 0 && !isFacingRight)
        {
            spriteRenderer.flipX = false;
            isFacingRight = true;
        }
    }

    void OnJump(InputValue value)
    {
        if (onFloor)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnDash()
    {
        Debug.Log("dash");
        if (isFacingRight)
            rb.AddForce(new Vector2(2 * speed, 0), ForceMode2D.Impulse);
        else
            rb.AddForce(new Vector2(-2 * speed, 0), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            Debug.Log("score: " + score);
            ++score;
        }
    }
}
