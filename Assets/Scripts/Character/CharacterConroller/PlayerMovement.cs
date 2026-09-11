using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private Transform cameraTransform;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpHeight = 1.6f;
    [SerializeField] private float gravity = -18f;
    [SerializeField] private float rotationSpeed = 15f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.15f;   
    private float coyoteTimeCounter;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        // Coyote time logic
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            if (velocity.y < 0)
                velocity.y = -2f;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // ----- Movement (relative to camera) -----
        Vector3 inputDirection = new Vector3(inputReader.MoveInput.x, 0f, inputReader.MoveInput.y).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 moveDirection = cameraTransform.forward * inputDirection.z + cameraTransform.right * inputDirection.x;
            moveDirection.y = 0f;
            moveDirection.Normalize();

            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        // ----- Aim / Face Direction (Mouse) -----
        HandleAiming();

        // ----- Jump (with coyote time) -----
        if (inputReader.JumpPressed && coyoteTimeCounter > 0f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            coyoteTimeCounter = 0f; // Prevent double jumping in the window
            inputReader.ResetOneFrameInputs();
        }

        // ----- Gravity -----
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }

    private void HandleAiming()
    {
        if (Mouse.current == null) return;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 lookPoint = ray.GetPoint(distance);
            Vector3 direction = lookPoint - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}