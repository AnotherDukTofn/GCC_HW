using UnityEngine;

public class Cell : MonoBehaviour {
    [SerializeField] private GameObject onCell;
    public bool isOccupied { get; private set; }

    public void AdjustObject() {
        if (onCell == null) return;
        onCell.transform.position = transform.position;
    }

    public void PlaceOn(GameObject obj) {
        onCell = obj;
        isOccupied = true;
        AdjustObject();
    }
}
