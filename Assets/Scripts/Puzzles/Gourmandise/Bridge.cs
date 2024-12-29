using System.Security.Cryptography;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bridge : MonoBehaviour {

    private bool isBroken = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !isBroken && wck.player.wax >= wck.bridge.weightLimit) {
            BreakPlank();
        }
    }

    private void BreakPlank() {
        isBroken = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Permet à la planche de tomber
        }
        // Ajoute un effet visuel ou sonore ici
        Destroy(gameObject, 2f); // Supprime la planche après 2 secondes
    }
}
