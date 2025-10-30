using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseDetector : MonoBehaviour {
    [SerializeField] private PatrolEnemy enemy;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            enemy.chaseTarget = other.transform;
            enemy.isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            enemy.isChasing = false;
        }
    }
}
