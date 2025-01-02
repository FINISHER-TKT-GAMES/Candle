using UnityEngine;

public class Torch : MonoBehaviour {

    [Header("Scripts")]
    public Engine engine;
    public End end;

    [Header("Paramètres")]
    public LayerMask playerLayer;
    

    [Header("Torche")]
    [SerializeField] private int ID;
    public Transform torchPos;
    public Light torchLight;
    

    [Header("Debug")]
    [SerializeField] private bool playerNear = false;
    [SerializeField] private lightState currentState = lightState.off;
    
    private enum lightState {off, ignited, on}


    void Start() {
        torchLight.intensity = 0f;

        if (ID == 1) {
            Ignite();
        }
    }

    void Update() {
        if (currentState != lightState.on) {
            playerNear = engine.ScanAround(torchPos.position, wck.torch.detectionRange, playerLayer);
            
            if (playerNear) {
            wck.player.currentTorch = ID;
            wck.player.torchCount++;
            CheckTorchCount();
            }  
        }
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

    // Contrôle la lumière des torches
    private void HandleLighting() {
        if (playerNear && ID == wck.player.currentTorch) {
            LightUp();
        }

        if (ID == wck.player.currentTorch + 1 && currentState == lightState.off) {
            Ignite();
        }
    }

    // Vérifie si le joueur a activé toutes les torches
    private void CheckTorchCount() {
        Debug.Log("torch count: " + wck.player.torchCount);
        if (wck.player.torchCount >= wck.player.torchMax) {
            end.Unlock();
        }
    }
}
