using UnityEngine;

public class GridDraw : MonoBehaviour {
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private Vector2 cellSize; 
    [SerializeField] private GameObject center;
    [SerializeField] Vector3 anchor;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        anchor = AnchorUpdate();

        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                Vector3 cellCenter = anchor + new Vector3(x * cellSize.x + cellSize.x / 2, y * cellSize.y + cellSize.y / 2, 0);

                Vector3 cellSizee = new Vector3(cellSize.x, cellSize.y, 0);
                Gizmos.DrawWireCube(cellCenter, cellSizee);
            }
        }
    }

    
    private Vector3 AnchorUpdate() {
        float totalWidth = gridSize.x * cellSize.x;
        float totalHeight = gridSize.y * cellSize.y;
        return center.transform.position - new Vector3(totalWidth / 2, totalHeight / 2, 0);
    }

    private void OnMouseDown() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        anchor = AnchorUpdate();

        Vector2Int gridPos = ConvertToGrid(mousePos);
        Debug.Log($"Ô được click: {gridPos}");
    }

    private Vector2Int ConvertToGrid(Vector3 worldPos) {
        Vector3 localPos = worldPos - anchor;

        int col = Mathf.FloorToInt(localPos.x / cellSize.x);
        int row = Mathf.FloorToInt(localPos.y / cellSize.y);

        return new Vector2Int(col, row);
    }
}