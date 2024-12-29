using UnityEditor.Callbacks;
using UnityEngine;

public class Bridge : MonoBehaviour {

     public float weightThreshold = 50f; // Poids maximum avant destruction
    private bool isBroken = false; // Pour éviter plusieurs destructions

    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        Rigidbody rb = collision.rigidbody;
        if (rb != null && rb.mass > weightThreshold)
        {
            Debug.Log("Planche cassée !");
            BreakPlank();
        }
    }

    private void BreakPlank()
    {
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
