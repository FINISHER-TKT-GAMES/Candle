using UnityEngine;

public class Room : MonoBehaviour {

    public void UpdateRoom() {
        Debug.Log(wck.player.statueCount);
        if (wck.player.statueCount >= wck.player.statueMax) {
            Debug.Log("La pièce s'effondre");
            // Code
        }
        else {
            wck.statue.requestIncrease = true;
        }
    }
}
