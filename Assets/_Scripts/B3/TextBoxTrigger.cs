using System.Collections;
using UnityEngine;

public class Char2 : MonoBehaviour {
    [SerializeField] private bool firstEncounter;
    [SerializeField] private SpriteRenderer textBox;
    [SerializeField] private bool textBoxOn;

    void Start() {
        Debug.Log("Start");
        textBox.gameObject.SetActive(false);
        firstEncounter = true;
    }

    void Update() {
        textBox.gameObject.SetActive(textBoxOn);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (firstEncounter && other.CompareTag("Player")) {
            firstEncounter = false;
            StartCoroutine(ShowTextBox());
        } 
    }

    private IEnumerator ShowTextBox() {
        textBoxOn = true;
        yield return new WaitForSeconds(2f);
        textBoxOn = false;
    }
}