using UnityEngine;

public class PatrolEnemy : BaseEnemy, IPatrol {
    [SerializeField] private Vector2[] patrolPoints;
    [SerializeField] private int nextPatrolPoint;
    [SerializeField] private int patrolDirection = 1;
    public Transform chaseTarget;
    public bool isChasing;

    private void Update() {
        if (isChasing) {
            Chase();
        } else {
            Patrol();
        }
    }

    public void Patrol() {
        if (patrolPoints.Length == 0) return; // Avoid error if no points

        Vector2 target = patrolPoints[nextPatrolPoint];
        if (Vector2.Distance(transform.position, target) > 0.25f) {
            float direction = Mathf.Sign(target.x - transform.position.x);
            Move(direction);
        } else {
            nextPatrolPoint += patrolDirection;
            if (nextPatrolPoint >= patrolPoints.Length || nextPatrolPoint < 0) {
                patrolDirection = -patrolDirection;
                nextPatrolPoint = Mathf.Clamp(nextPatrolPoint + patrolDirection, 0, patrolPoints.Length - 1);
            }
        }
    }

    public void Chase() {
        if (chaseTarget == null) return; 

        Vector2 targetPos = chaseTarget.position;
        if (Vector2.Distance(transform.position, targetPos) > 0.2f) {
            float direction = Mathf.Sign(targetPos.x - transform.position.x);
            Move(direction);
        } else {
            // Attack 
        }
    }
}