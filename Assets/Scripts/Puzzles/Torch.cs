using UnityEngine;

public class Torch : MonoBehaviour {

    public Transform torchPos;
    public LayerMask playerLayer;

    private bool playerNear = false;

    void Update() {
        Scan();
    }


    private void Ignite() {

    }

    private void LightUp() {

    }

    private void LightOff() {

    }

    private void Scan() {
        playerNear = Physics.CheckSphere(torchPos.position, 0.3f, playerLayer);
        Debug.Log("player is nearby!");
    }

}
