using UnityEngine;

public class Torch : MonoBehaviour {

    // ID
    [SerializeField] private int ID;

    // Détection
    public Transform torchPos;
    public LayerMask playerLayer;
    private bool playerNear = false;
    private float detectionRange = 5f;

    // Lumière
    public Light torchLight;
    private lightState currentState = lightState.off;
    private enum lightState {
        off,
        ignited,
        on
    }


    void Start() {
        if (ID == 1) {
            Ignite();
        }
    }

    void Update() {
        Scan();
        HandleLighting();
    }

    // Allume légèrement la flamme de la torche
    private void Ignite() {
        currentState = lightState.ignited;
    }

    // Allume complètement la flamme de la torche
    private void LightUp() {
        currentState = lightState.on;
    }

    // Scan si le joueur est autour de la torche
    private void Scan() {
        if (currentState != lightState.on) {
            playerNear = Physics.CheckSphere(torchPos.position, detectionRange, playerLayer);  
            
            if (playerNear) {
            wck.player.currentTorch = ID;
            Debug.Log("Player is near torch " + ID + "Light: " + currentState);
            }  
        }
    }

    // Contrôle la lumière des torches
    private void HandleLighting() {
        if (playerNear && ID == wck.player.currentTorch && currentState == lightState.ignited) {
            LightUp();
        }

        if (ID == wck.player.currentTorch + 1) {
            Ignite();
        }
    }
}
