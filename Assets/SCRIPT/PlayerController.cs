using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float direction;
    public float speed;
    public Rigidbody2D rb;

    public float jumpForce;
    public Transform groundCheck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    rb.linearVelocity=new Vector2(direction*speed, rb.linearVelocityY);    
    }

    public void Move(InputAction.CallbackContext context)
    {
     direction= context.ReadValue<Vector2>().x;   
    }
}
