using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerInteractionDetector : MonoBehaviour {
    [field: SerializeField] public BaseItem Item { get; private set; }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Item")) {
            Item = other.GetComponent<BaseItem>();
            Debug.Log(Item.GetType().Name);
        }
    }

    // void OnTriggerExit2D(Collider2D other) {
    //     if (other.CompareTag("Item") && other.G != Item) {
    //         Item = null;
    //     }
    // }
}