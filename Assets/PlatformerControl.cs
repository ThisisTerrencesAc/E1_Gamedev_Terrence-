using UnityEngine;
using UnityEngine.InputSystem;


public class PlatformerControl : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    bool onFloor = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        rb.linearVelocity = new Vector2(input.x * speed, rb.linearVelocity.y);
    }

    void OnJump(InputValue value)
    {
        if (onFloor)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnDash(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        rb.AddForce(new Vector2(2 * input.x * speed, 0), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor = true;
        }

        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Debug.Log("score: " + score);
            ++score;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }
}
