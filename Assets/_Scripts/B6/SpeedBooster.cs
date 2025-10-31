using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : BaseItem, IConsumable {
    [SerializeField] private float boostAmount;
    [SerializeField] private float boostDuration;

    public void Consume(GameObject target) {
        if (target.TryGetComponent<PlayerData>(out var data)) {
            StartCoroutine(BoostRoutine(data));
        }
    }

    private IEnumerator BoostRoutine(PlayerData data) {
        data.Boost(boostAmount);      
        Debug.Log("Boost to " + data.GetSpeed());
        yield return new WaitForSeconds(boostDuration);
        data.Slow(boostAmount);
        Debug.Log("Slow down to " + data.GetSpeed());
    }
    public override void Interact(GameObject interactor) {
        Consume(interactor);
    }
}
