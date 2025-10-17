using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    [SerializeField] private GameObject visual;
    [SerializeField] private bool dragging;
    private Vector2 offset;

    void OnMouseDown() {
        dragging = true;
        offset = GetMousePosition() - (Vector2) visual.transform.position;
    }

    void OnMouseUp() {
        dragging = false;

        Vector2 mousePos = GetMousePosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject != this.gameObject && hit.collider.CompareTag("ItemSlot")) {
            
            Transform target = hit.collider.transform;

            transform.position = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
            );

        }
        else {
            visual.transform.position = Vector3.zero;
        }

        visual.transform.localPosition = Vector3.zero;
    }

    void Update() {
        if (dragging) {
            Vector2 mousePos = GetMousePosition();
            visual.transform.position = new Vector3(
                mousePos.x - offset.x,
                mousePos.y - offset.y,
                visual.transform.position.z
            );
        }
    }

    private Vector2 GetMousePosition() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}