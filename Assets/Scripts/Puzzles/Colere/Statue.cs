using UnityEngine;

public class Statue : MonoBehaviour {

    [SerializeField] private Room room;

    public new Light light;

    // OPTI: FONCTION QUI APPELLE INCREASE LIGHT AU LIEU DE VOID UPDATE
    void Update() {
        if (wck.statue.requestIncrease) {
            IncreaseLight();
            wck.statue.requestIncrease = false;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            wck.player.statueCount++;
            room.UpdateRoom();
            Destroy(gameObject);
        }
    }

    public void IncreaseLight() {
        light.intensity += wck.statue.lightIncrease;
    }
}
