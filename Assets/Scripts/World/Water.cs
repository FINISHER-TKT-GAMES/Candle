using UnityEngine;

public class Water : MonoBehaviour {

    public PlayerManager player;
    public Light flameLight;

    void OnTriggerEnter(Collider collider) {
        flameLight.intensity = 0;
        player.Die();
    }

}
