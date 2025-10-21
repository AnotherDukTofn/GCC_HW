using UnityEngine;
using System.Collections.Generic;

public class RangeDetect : MonoBehaviour {
    public List<Collider2D> inRange = new List<Collider2D>();
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log(other.name + " entered range");
            inRange.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log(other.name + " exited range");
            inRange.Remove(other);
        }
    }
}