using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerCharacterInputAction inputActions;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool InteractPressed { get; private set; }

    public bool Ability1Pressed { get; private set; }
    public bool Ability2Pressed { get; private set; }
    public bool Ability3Pressed { get; private set; }
    public bool Ability4Pressed { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerCharacterInputAction();
    }

    private void OnEnable()
    {
        inputActions.PlayerControls.Enable();

        // Movement & Look
        inputActions.PlayerControls.Movement.performed += OnMove;
        inputActions.PlayerControls.Movement.canceled  += OnMoveCanceled;

        inputActions.PlayerControls.Look.performed += OnLook;
        inputActions.PlayerControls.Look.canceled  += OnLookCanceled;

        // One-frame buttons
        inputActions.PlayerControls.Jump.performed   += OnJump;
        inputActions.PlayerControls.PickUp.performed += OnPickUp;

        inputActions.PlayerControls.Ability_1.performed += OnAbility1;
        inputActions.PlayerControls.Ability_2.performed += OnAbility2;
        inputActions.PlayerControls.Ability_3.performed += OnAbility3;
        inputActions.PlayerControls.Ability_4.performed += OnAbility4;
    }

    private void OnDisable()
    {
        // Unsubscribe everything
        inputActions.PlayerControls.Movement.performed -= OnMove;
        inputActions.PlayerControls.Movement.canceled  -= OnMoveCanceled;

        inputActions.PlayerControls.Look.performed -= OnLook;
        inputActions.PlayerControls.Look.canceled  -= OnLookCanceled;

        inputActions.PlayerControls.Jump.performed   -= OnJump;
        inputActions.PlayerControls.PickUp.performed -= OnPickUp;

        inputActions.PlayerControls.Ability_1.performed -= OnAbility1;
        inputActions.PlayerControls.Ability_2.performed -= OnAbility2;
        inputActions.PlayerControls.Ability_3.performed -= OnAbility3;
        inputActions.PlayerControls.Ability_4.performed -= OnAbility4;

        inputActions.PlayerControls.Disable();
    }

    // ---- Callbacks ----
    private void OnMove(InputAction.CallbackContext ctx)        => MoveInput = ctx.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext ctx) => MoveInput = Vector2.zero;

    private void OnLook(InputAction.CallbackContext ctx)        => LookInput = ctx.ReadValue<Vector2>();
    private void OnLookCanceled(InputAction.CallbackContext ctx) => LookInput = Vector2.zero;

    private void OnJump(InputAction.CallbackContext ctx)
    {
        JumpPressed = true;
    }

    private void OnPickUp(InputAction.CallbackContext ctx)
    {
        InteractPressed = true;
        Debug.Log("PickUp input detected!");   // ← temporary debug
    }

    private void OnAbility1(InputAction.CallbackContext ctx) => Ability1Pressed = true;
    private void OnAbility2(InputAction.CallbackContext ctx) => Ability2Pressed = true;
    private void OnAbility3(InputAction.CallbackContext ctx) => Ability3Pressed = true;
    private void OnAbility4(InputAction.CallbackContext ctx) => Ability4Pressed = true;

    public void ResetOneFrameInputs()
    {
        JumpPressed = false;
        InteractPressed = false;
        Ability1Pressed = false;
        Ability2Pressed = false;
        Ability3Pressed = false;
        Ability4Pressed = false;
    }
}