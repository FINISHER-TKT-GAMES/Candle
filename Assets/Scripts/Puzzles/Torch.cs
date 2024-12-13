using UnityEngine;

public class Torch : MonoBehaviour {

    // Import
    public End end;

    // ID
    [SerializeField] private int ID;

    // Détection
    public Transform torchPos;
    public LayerMask playerLayer;
    private bool playerNear = false;

    // Lumière
    public Light torchLight;
    private lightState currentState = lightState.off;
    private enum lightState {
        off,
        ignited,
        on
    }


    void Start() {
        torchLight.intensity = 0f;

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
        torchLight.intensity = wck.torch.lowIntensity;
        currentState = lightState.ignited;
    }

    // Allume complètement la flamme de la torche
    private void LightUp() {
        torchLight.intensity = wck.torch.highIntensity;
        currentState = lightState.on;
    }

    // Scan si le joueur est autour de la torche
    private void Scan() {
        if (currentState != lightState.on) {
            playerNear = Physics.CheckSphere(torchPos.position, wck.torch.detectionRange, playerLayer);  
            
            if (playerNear) {
            wck.player.currentTorch = ID;
            wck.player.torchCount++;
            CheckTorchCount();
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

    private void CheckTorchCount() {
        Debug.Log("torch count: " + wck.player.torchCount);
        if (wck.player.torchCount >= 3) {
            end.Unlock();
        }
    }
}
