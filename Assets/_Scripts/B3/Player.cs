using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [field: SerializeField] public PlayerInput Input {get; private set;}
    [field: SerializeField] public PlayerAction Action { get; private set; }
    [field: SerializeField] public PlayerInteractionDetector Interactor {get; private set;}
    [field: SerializeField] public PlayerData Data {get; private set;}

    void Update() {
        Action.Move(Input.MoveInput);
        
        if (Input.JumpPressed) {
            Action.Jump();
        }

        if (Input.InteractPressed) {
            Interactor.Item.Interact(this.gameObject);
        }
    }
}
