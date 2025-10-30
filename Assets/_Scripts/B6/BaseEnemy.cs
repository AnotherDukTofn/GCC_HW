using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour {
    [SerializeField] protected float MaxHealth, Damage, CurrentHealth, Speed;
    [SerializeField] protected Rigidbody2D _rb;

    public void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void TakeDamage(int damage) {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0) Die();
    }

    public void Die() {
        // play anim Die;
        this.gameObject.SetActive(false);
    }

    public void Move(float moveDirection) {
        _rb.velocity = new Vector2(moveDirection * Speed, _rb.velocity.y);
    }
}
