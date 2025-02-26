using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Wax : MonoBehaviour {

    [SerializeField] private PlayerManager player;
    [SerializeField] private Reset reset;

    void Start() {
        StartCoroutine(LoseWax());
    }

    void Update() {
        BurnFaster(3);
    }

    // Permet de récupérer de la cire
    public void PickupWax(float amount) {
        if (player.data.wax < player.data.waxMax) {
            if (player.data.wax + amount < player.data.waxMax) {
                player.data.wax += amount;
            }
            else {
                player.data.wax = player.data.waxMax;
            }
        }
    }

    // Fait diminuer la cire du joueur au fil du temps
    private IEnumerator LoseWax() {
        while (player.data.wax >= player.data.waxMin) {
            yield return new WaitForSeconds(player.data.waxSpeed);
            player.data.waxDecay = player.data.temperature/100;
            player.data.wax -= player.data.waxDecay;
        }
        reset.ResetWorld();
        player.data.wax = player.data.waxSpawn;
    }

    // FIX: Il y a un petit temps avant que BurnFaster s'active
    //      car il faut attendre la prochaine boucle de LoseWax()
    // Permet de brûler notre cire plus vite
    private void BurnFaster(float multiplier) {
        if (Input.GetKey(KeyCode.R)) {
            player.data.waxSpeed = player.data.waxDefaultSpeed / multiplier;
            player.data.waxSpeedState = SpeedState.boost;
        } else {
            player.data.waxSpeed = player.data.waxDefaultSpeed;
            player.data.waxSpeedState = SpeedState.normal;
        }
    }
    
}
