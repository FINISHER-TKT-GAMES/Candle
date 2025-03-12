using System.Collections;
using UnityEngine;

public class Wind : MonoBehaviour {

    public PlayerManager player;
    public Transform playerObject;
    public Rigidbody playerRb;
    public Light flameLight;

    public float windForce;

    // Réduit l'intensité de la flamme jusqu'à l'éteindre
    private IEnumerator BlowFlame() {
        float time = 0;
        while (time < player.data.windResistance) {
            yield return new WaitForSeconds(1);
            time++;
            flameLight.intensity -= 0.3f;
            // flameLight.intensity -= player.data.maxIntensity / player.data.windResistance;
        }
        flameLight.intensity = 0;
        player.Die();
    }

    // Trouve le vecteur [Origine vent - Joueur]
    private Vector3 GetVector() {
        return playerObject.transform.position - transform.position;
    }

    // Repousse le joueur
    private void PushPlayer() {
        playerRb.AddForce(GetVector() * windForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            StartCoroutine(BlowFlame());
        }
    }

    private void OnTriggerStay(Collider collider) {
        PushPlayer();
    }

    private void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
        }
    }
}
