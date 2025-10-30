using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape {
    void OnTriggerEnter2D(Collider2D other) {
        Trigger();
    }
}