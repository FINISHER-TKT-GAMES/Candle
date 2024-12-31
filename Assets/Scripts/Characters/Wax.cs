using UnityEngine;
using System.Collections;

public class Wax : MonoBehaviour {

    void Start() {
        StartCoroutine(LoseWax());
    }

    void Update() {
        // BurnFaster(10);
    }

    // Permet de récupérer de la cire
    private void PickupWax(float amount) {
        if (wck.player.wax < wck.player.waxMax) {
            if (wck.player.wax + amount > wck.player.waxMax) {
                wck.player.wax += amount;
            }
            else {
                wck.player.wax = wck.player.waxMax;
            }
        }
    }

    // Fait diminuer la cire du joueur au fil du temps
    private IEnumerator LoseWax() {
        while (wck.player.wax >= wck.player.waxMin) {
            yield return new WaitForSeconds(wck.player.waxSpeed);
            wck.player.wax -= wck.player.waxDecay;
            Debug.Log("Wax left: " + wck.player.wax); // DEBUG
        }
    }

    // WIP
    // Permet de brûler notre cire plus vite
    private void BurnFaster(float multiplier) {
        if (Input.GetKeyDown(wck.ctrl.burnFaster)) {
            wck.player.waxSpeed *= multiplier;
            wck.player.waxSpeedState = SpeedState.boost;
            Debug.Log("Wax speed: " + wck.player.waxSpeed); // DEBUG
            Debug.Log("Speed state: " + wck.player.waxSpeedState); // DEBUG
        } else {
            wck.player.waxSpeed = wck.player.waxDefaultSpeed;
            wck.player.waxSpeedState = SpeedState.normal;
        }
    }
    
}
