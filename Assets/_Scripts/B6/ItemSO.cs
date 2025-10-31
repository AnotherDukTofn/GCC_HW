using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject {
    public string itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public void Awake() {
        if (string.IsNullOrEmpty(itemID)) {
            itemID = Guid.NewGuid().ToString();
        }
    }
}
