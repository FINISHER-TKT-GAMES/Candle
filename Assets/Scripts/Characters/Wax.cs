using UnityEngine;
using System.Collections;

public class Wax : MonoBehaviour {

    void Start() {
        StartCoroutine(LoseWax());
    }

    void Update() {
    }

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

    private IEnumerator LoseWax() {
        while (wck.player.wax >= wck.player.waxMin) {
            yield return new WaitForSeconds(wck.player.waxSpeed);
            wck.player.wax -= wck.player.waxDecay;
            Debug.Log("Wax left: " + wck.player.wax); // DEBUG
        }
    }
}
