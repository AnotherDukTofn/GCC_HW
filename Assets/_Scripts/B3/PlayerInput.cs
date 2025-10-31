using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    [field: SerializeField] public float MoveInput { get; private set; }
    [field: SerializeField] public bool JumpPressed { get; private set; }
    [field: SerializeField] public bool InteractPressed { get; private set; }
    
    public void OnMove(InputAction.CallbackContext ctx) {
        MoveInput = ctx.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext ctx) {
        JumpPressed = ctx.ReadValueAsButton();
    }

    public void OnInteract(InputAction.CallbackContext ctx) {
        InteractPressed = ctx.ReadValueAsButton();
    }
}
