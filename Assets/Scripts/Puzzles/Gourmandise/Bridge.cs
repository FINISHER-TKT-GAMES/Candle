using UnityEngine;

public class Bridge : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    private bool isBroken = false;

    // Détecte le joueur et casse les planches sous ses pieds si son poids est trop elevé
    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && !isBroken && player.data.wax >= wck.bridge.weightLimit) {
            BreakPlank();
        }
    }

    // Détruit la planche en lui faisant subir la gravité
    private void BreakPlank() {
        isBroken = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = false; // Permet à la planche de tomber
        }
        Destroy(gameObject, 2f); // Supprime la planche après 2 secondes
    }
}
