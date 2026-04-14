using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{
    private float moveX;
    private float moveY;

    [SerializeField] private float moveSpeed = 5f;

    void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        Debug.Log("Input Vector: " + inputVector);
        moveX = inputVector.x;
        moveY = inputVector.y;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float XmoveDistance = moveX * moveSpeed * Time.deltaTime;
        float YmoveDistance = moveY * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }
}
