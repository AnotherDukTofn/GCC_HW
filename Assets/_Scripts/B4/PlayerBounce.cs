using System;
using UnityEngine;
using System.Collections;

public class PlayerBounce : MonoBehaviour {
    [Header("Parameter & Reference")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float recoverSpeed;   // tốc độ hồi scale
    [SerializeField] private float squashTime;  
    [SerializeField] private float recoverBounds;
    [SerializeField] private bool onGround;

    [Header("Scales")]
    public Vector3 originalScale = new Vector3(1f, 1f, 1f);
    public Vector3 stretchedScale = new Vector3(0.8f, 1.2f, 1f);
    public Vector3 squashedScale = new Vector3(1.2f, 0.8f, 1f);

    [Header("STATE")] 
    [SerializeField] private bool isStretching;
    [SerializeField] private bool isSquashing;
    [SerializeField] private bool isRecovering;

    void Start() {
        originalScale = transform.localScale;
    }

    void Update() {
        float velY = rb.velocity.y;

        if (isSquashing) return;

        if (velY > -recoverBounds && velY < recoverBounds) {
            Recover();
        }
        else {
            Stretch();
        }
    }

    void Stretch() {
        if (isStretching) return;
        StopAllCoroutines();
        isStretching = true;
        isRecovering = false;
        isSquashing = false;
        StartCoroutine(LerpScale(stretchedScale));
    }

    void Squash() {
        if (isSquashing) return;
        StopAllCoroutines();
        isSquashing = true;
        isStretching = false;
        isRecovering = false;
        StartCoroutine(SquashingRoutine());
    }

    void Recover() {
        if (isRecovering) return;
        StopAllCoroutines();
        isRecovering = true;
        isStretching = false;
        isSquashing = false;
        StartCoroutine(LerpScale(originalScale));
    }

    IEnumerator LerpScale(Vector3 target) {
        while (Vector3.Distance(transform.localScale, target) > 0.01f) {
            transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * recoverSpeed);
            yield return null;
        }
        transform.localScale = target;
    }

    IEnumerator SquashingRoutine() {
        yield return StartCoroutine(LerpScale(squashedScale));
        yield return new WaitForSeconds(squashTime);
        isSquashing = false;
        Recover();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")) {
            Squash();
            Debug.Log("Squashed");
        }
    }
}
