using UnityEngine;

public class PlayerAction : MonoBehaviour {
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Player player;
    
    [SerializeField] private float MoveSpeed => player.Data.GetSpeed();
    [SerializeField] private float JumpForce => player.Data.GetJumpForce();
    public bool onGround;

    private void Awake() {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        onGround = Grounded();
    }
    
    public void Move(float moveInput) {
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), transform.localScale.y, transform.localScale.z);
    }

    public void Jump() {
        if (onGround) 
            rb.velocity = new Vector2(rb.velocity.x, player.Data.JumpForce);
    }

    private bool Grounded() {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.25f), 0.5f, LayerMask.GetMask("Ground"));
    }
}
