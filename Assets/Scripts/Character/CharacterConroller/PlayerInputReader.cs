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

        inputActions.PlayerControls.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Movement.canceled  += ctx => MoveInput = Vector2.zero;

        inputActions.PlayerControls.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Look.canceled  += ctx => LookInput = Vector2.zero;

        inputActions.PlayerControls.Jump.performed += ctx => JumpPressed = true;
        inputActions.PlayerControls.PickUp.performed += ctx => InteractPressed = true;

        inputActions.PlayerControls.Ability_1.performed += ctx => Ability1Pressed = true;
        inputActions.PlayerControls.Ability_2.performed += ctx => Ability2Pressed = true;
        inputActions.PlayerControls.Ability_3.performed += ctx => Ability3Pressed = true;
        inputActions.PlayerControls.Ability_4.performed += ctx => Ability4Pressed = true;
    }

    private void OnDisable()
    {
        inputActions.PlayerControls.Disable();
    }

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