using UnityEngine;

public class Ball_Bounce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float bounceForce = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
            rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
    }
}
