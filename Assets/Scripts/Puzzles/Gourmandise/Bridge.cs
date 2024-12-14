using UnityEngine;

public class Bridge : MonoBehaviour {

    public Transform BridgePos;
    public LayerMask playerLayer;

    private bool isPlayerHere;

    void Update() {
        if (isPlayerHere) {
            CheckWeight();
        }
    }

    // Vérifie si le joueur est sur le pont
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            isPlayerHere = true;
        } else {
            isPlayerHere = false;
        }
    }

    // Vérifie si le poids du joueur dépasse la limite de poids du pont
    private void CheckWeight() {
        if (wck.player.wax >= wck.bridge.weightLimit) {
            AllowBreaking();
        }
    }

    // Détruit le pont
    // A finir
    private void AllowBreaking() {
        wck.bridge.isBreakable = true;
    }
}
