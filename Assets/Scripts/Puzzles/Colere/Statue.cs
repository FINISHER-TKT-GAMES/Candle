using UnityEngine;

public class Statue : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    [SerializeField] private Room room;
    [SerializeField] new Light light;

    // OPTI: FONCTION QUI APPELLE INCREASE LIGHT AU LIEU DE VOID UPDATE
    void Update() {
        light.intensity = player.data.statueCount+1;
    }

    // Ajoute 1 au compte de statues et met à jour la pièce
    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            player.data.statueCount++;
            room.UpdateRoom();
            Destroy(gameObject);
        }
    }
}
