using UnityEngine;

public class Torch : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

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
            player.data.currentTorch = ID;
            player.data.torchCount++;
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
        if (playerNear && ID == player.data.currentTorch) {
            LightUp();
        }

        if (ID == player.data.currentTorch + 1 && currentState == lightState.off) {
            Ignite();
        }
    }

    // Vérifie si le joueur a activé toutes les torches
    private void CheckTorchCount() {
        Debug.Log("torch count: " + player.data.torchCount);
        if (player.data.torchCount >= player.data.torchMax) {
            end.Unlock();
        }
    }
}
