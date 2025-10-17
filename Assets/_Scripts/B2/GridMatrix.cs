using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class GridMatrix : MonoBehaviour {
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private Vector2 cellSize;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject center;
    [SerializeField] private Vector3 anchor;
    [SerializeField] private float spacing;

    private GameObject CellUpdate(GameObject cell) {
        cell.transform.localScale = (Vector3) cellSize;
        return cell;
    }
    
    private Vector3 AnchorUpdate() {
        float width = gridSize.x * cellSize.x;
        float height = gridSize.y * cellSize.y;
        return center.transform.position - new Vector3(width / 2, height / 2, -10f);
    }

    private void InitGrid() {
        anchor = AnchorUpdate();
        for (int i = 0; i < gridSize.x; i++) {
            for (int j = 0; j < gridSize.y; j++) {
                Vector3 cellPos = anchor + new Vector3((i * 1f + 0.5f) * (cellSize.x + spacing), 
                                                       (j * 1f + 0.5f) * (cellSize.y + spacing), 0);
                GameObject cell = Instantiate(cellPrefab, cellPos, Quaternion.identity, transform);
                cell = CellUpdate(cell);
            }
        }
    }

    private void Start() {
        InitGrid();
    }
    
    
}
