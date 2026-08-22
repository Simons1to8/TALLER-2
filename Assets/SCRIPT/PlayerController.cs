using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float direction;
    public float speed;
    public Rigidbody2D rb;

    [SerializeField] private float jumpForce;
    public bool canJump;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private LayerMask GroundLayer;

    public GameObject Key;
    public GameObject Door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        canJump = Physics2D.OverlapCircle(GroundCheck.position,GroundCheckRadius,GroundLayer);


      rb.linearVelocity=new Vector2(direction*speed, rb.linearVelocityY);
      //rb.AddForceX(direction * speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")){

            collision.gameObject.SetActive(false);
            Door.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Copa")){
            collision.gameObject.SetActive(false);
          

        }
    }
}
