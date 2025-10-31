using UnityEditor;
using UnityEngine;

public class HealPotion : BaseItem, IConsumable {
    [SerializeField] private float healAmount;
    public void Consume(GameObject target) {
        if (target.TryGetComponent<PlayerData>(out var data)) {
            data.Heal(healAmount);
        }
        Debug.Log($"Healing {healAmount} for {target.name}");
    }

    public override void Interact(GameObject interactor) {
        Consume(interactor);
    }
}