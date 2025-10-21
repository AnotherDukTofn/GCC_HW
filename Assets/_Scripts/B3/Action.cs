using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action : MonoBehaviour {
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Punch Settings")]
    [SerializeField] private float punchPower = 10f;
    
    [Header("Ahihi")]
    [SerializeField] private RangeDetect range;

    private float moveInput;
    private float facingDir = 1f;

    private void Start() {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Move();
    }

    // --- Input Callbacks ---
    public void OnMove(InputAction.CallbackContext ctx) {
        moveInput = ctx.ReadValue<float>();
    }

    public void OnPunch(InputAction.CallbackContext ctx) {
        if (ctx.performed)
            Punch();
    }

    // --- Movement ---
    private void Move() {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput != 0)
            facingDir = Mathf.Sign(moveInput);

        transform.localScale = new Vector3(facingDir, 1f, 1f);
    }

    // --- Punch Logic (using Raycast2D) ---
    private void Punch() {
        foreach (var col in range.inRange) {
            Vector2 forceDir = (col.transform.position - transform.position).normalized;
            col.GetComponent<Rigidbody2D>().AddForce(forceDir * punchPower, ForceMode2D.Impulse);
        }
    }
}
