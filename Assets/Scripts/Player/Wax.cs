using UnityEngine;
using System.Collections;

public class Wax : MonoBehaviour {

<<<<<<< HEAD:Assets/Scripts/Player/Wax.cs
    [SerializeField]
    private PlayerManager player;

    [SerializeField] private float waxLeft; // DEBUG

=======
>>>>>>> feature/moteurPhysique:Assets/Scripts/Characters/Wax.cs
    void Start() {
        StartCoroutine(LoseWax());
    }

    void Update() {
<<<<<<< HEAD:Assets/Scripts/Player/Wax.cs
        waxLeft = player.data.wax;
         BurnFaster(0.1f);
=======
        // BurnFaster(10);
>>>>>>> feature/moteurPhysique:Assets/Scripts/Characters/Wax.cs
    }

    // Permet de récupérer de la cire
    public void PickupWax(float amount) {
<<<<<<< HEAD:Assets/Scripts/Player/Wax.cs
        if (player.data.wax < player.data.waxMax) {
            if (player.data.wax + amount < player.data.waxMax) {
                player.data.wax += amount;
            }
            else {
                player.data.wax = player.data.waxMax;
=======
        if (wck.player.wax < wck.player.waxMax) {
            if (wck.player.wax + amount < wck.player.waxMax) {
                wck.player.wax += amount;
            }
            else {
                wck.player.wax = wck.player.waxMax;
>>>>>>> feature/moteurPhysique:Assets/Scripts/Characters/Wax.cs
            }
        }
    }

    // Fait diminuer la cire du joueur au fil du temps
    private IEnumerator LoseWax() {
<<<<<<< HEAD:Assets/Scripts/Player/Wax.cs
        while (player.data.wax >= player.data.waxMin) {
            yield return new WaitForSeconds(player.data.waxSpeed);
            player.data.wax -= player.data.waxDecay;
=======
        while (wck.player.wax >= wck.player.waxMin) {
            yield return new WaitForSeconds(wck.player.waxSpeed);
            wck.player.wax -= wck.player.waxDecay;
            Debug.Log("Wax left: " + wck.player.wax); // DEBUG
>>>>>>> feature/moteurPhysique:Assets/Scripts/Characters/Wax.cs
        }
    }

    // WIP
    // Permet de brûler notre cire plus vite
    private void BurnFaster(float multiplier) {
<<<<<<< HEAD:Assets/Scripts/Player/Wax.cs
        if (Input.GetKey(wck.ctrl.burnFaster)) {
            player.data.waxSpeed = player.data.waxDefaultSpeed * multiplier;
            player.data.waxSpeedState = SpeedState.boost;
            // Debug.Log("Wax speed: " + player.data.waxSpeed);  DEBUG
            //Debug.Log("Speed state: " + player.data.waxSpeedState);  DEBUG
        } else {
            player.data.waxSpeed = player.data.waxDefaultSpeed;
            player.data.waxSpeedState = SpeedState.normal;
=======
        if (Input.GetKeyDown(wck.ctrl.burnFaster)) {
            wck.player.waxSpeed *= multiplier;
            wck.player.waxSpeedState = SpeedState.boost;
            Debug.Log("Wax speed: " + wck.player.waxSpeed); // DEBUG
            Debug.Log("Speed state: " + wck.player.waxSpeedState); // DEBUG
        } else {
            wck.player.waxSpeed = wck.player.waxDefaultSpeed;
            wck.player.waxSpeedState = SpeedState.normal;
>>>>>>> feature/moteurPhysique:Assets/Scripts/Characters/Wax.cs
        }
    }
    
}
