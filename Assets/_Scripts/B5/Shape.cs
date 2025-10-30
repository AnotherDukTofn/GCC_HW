using UnityEngine;

public abstract class Shape : MonoBehaviour {
    [SerializeField] protected string shapeName;

    public void Trigger() {
        Debug.Log(shapeName);
    }
}
