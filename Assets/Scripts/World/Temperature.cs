using UnityEngine;

public class Temperature : MonoBehaviour {

    [SerializeField] private PlayerManager player;

    public float temp;

    public void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            player.data.temperature = temp;
        }
    }
}
