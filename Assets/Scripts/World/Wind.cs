using UnityEngine;

public class Wind : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Un objet est entré dans la zone de vent : " + other.name);
        if (other.CompareTag("Player")) {
            Debug.Log("Le joueur est détecté dans la zone de vent.");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Le joueur a quitté la zone de vent.");
        }
    }
}