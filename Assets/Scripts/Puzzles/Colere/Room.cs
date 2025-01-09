using UnityEngine;

public class Room : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    // Vérifie si trop de statues ont été détruites
    public void UpdateRoom() {
        if (player.data.statueCount >= player.data.statueMax) {
            Debug.Log("La pièce s'effondre");
            // Code
        }
    }
}
