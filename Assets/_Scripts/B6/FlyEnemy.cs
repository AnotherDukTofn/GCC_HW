using UnityEngine;

public class FlyEnemy : BaseEnemy, IFlyable {
    [SerializeField] private AnimationCurve flyVelocityCurve = new AnimationCurve(
        new Keyframe(0f, 0f),
        new Keyframe(0.25f, 1f),
        new Keyframe(0.5f, 0f),
        new Keyframe(0.75f, -1f),
        new Keyframe(1f, 0f)
    );
    [SerializeField] private float flyVelocity;
    [SerializeField] private float cycleTime;
    [SerializeField] private float cycleTimer;
    
    public void Fly() {
        float t = (cycleTimer % cycleTime) / cycleTime;
        float curveValue = flyVelocityCurve.Evaluate(t); 
        float velocityY = curveValue * flyVelocity;

        _rb.velocity = new Vector2(_rb.velocity.x, velocityY);
    }

    public void Update() {
        cycleTimer += Time.deltaTime;
        Fly();
    }
}