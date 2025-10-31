using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    
    public float GetSpeed() => Speed;
    public float GetJumpForce() => JumpForce;

    public void Heal(float amount) {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public void Boost(float amount) {
        Speed *= amount;
    }

    public void Slow(float amount) {
        Speed /= amount;
    }

    void Start() {
        CurrentHealth = MaxHealth;
    }
}
