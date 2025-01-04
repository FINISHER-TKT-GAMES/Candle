using UnityEngine;

public class Room : MonoBehaviour {

    // Vérifie si trop de statues ont été détruites
    public void UpdateRoom() {
        if (wck.player.statueCount >= wck.player.statueMax) {
            Debug.Log("La pièce s'effondre");
            // Code
        }
    }
}
