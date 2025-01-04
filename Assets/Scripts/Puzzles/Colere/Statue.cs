using UnityEngine;

public class Statue : MonoBehaviour {

    [SerializeField] private Room room;
    [SerializeField] new Light light;

    // OPTI: FONCTION QUI APPELLE INCREASE LIGHT AU LIEU DE VOID UPDATE
    void Update() {
        light.intensity = wck.player.statueCount+1;
    }

    // Ajoute 1 au compte de statues et met à jour la pièce
    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            wck.player.statueCount++;
            room.UpdateRoom();
            Destroy(gameObject);
        }
    }
}
