using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f; 
    public float jumpForce = 5f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded;

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction jumpAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = gameObject.AddComponent<PlayerInput>();
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += OnJump;
    }

    private void Update()
    {
        Move();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * direction;
            
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Vector3 move = moveDirection * (speed * Time.deltaTime);
            rb.MovePosition(rb.position + move);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
