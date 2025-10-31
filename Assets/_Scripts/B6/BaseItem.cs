using UnityEngine;

public abstract class BaseItem : MonoBehaviour {
    public ItemSO ItemData;
    public abstract void Interact(GameObject interactor);

    public void Awake() {
        GetComponent<SpriteRenderer>().sprite = ItemData.itemIcon;
    }
}