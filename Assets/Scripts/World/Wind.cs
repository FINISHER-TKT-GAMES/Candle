using System.Collections;
using UnityEngine;

public class Wind : MonoBehaviour {

    public PlayerManager player;
    public Light flameLight;

    public float windForce;

    public IEnumerator BlowFlame() {
        float time = 0;
        while (time < player.data.windResistance) {
            yield return new WaitForSeconds(1);
            time++;
            flameLight.intensity -= 0.3f;
            // flameLight.intensity -= player.data.maxIntensity / player.data.windResistance;
        }
        Debug.Log("Flame's out");
        flameLight.intensity = 0;
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            Debug.Log("Le joueur est détecté dans la zone de vent.");
            StartCoroutine(BlowFlame());
        }
    }

    // private void OnTriggerStay(Collider collider) {
        
    // }

    private void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            Debug.Log("Le joueur a quitté la zone de vent.");
        }
    }
}