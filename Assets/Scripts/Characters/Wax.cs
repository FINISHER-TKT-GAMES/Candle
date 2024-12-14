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
        Debug.Log("Wax left: " + wck.player.wax);
        while (wck.player.wax >= 1) {
            yield return new WaitForSeconds(0.05f);
            wck.player.wax -= wck.player.waxDecay;
        }
    }
}
