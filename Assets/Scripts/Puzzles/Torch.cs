using UnityEngine;

public class Torch : MonoBehaviour {

    [SerializeField] private int ID;

    public Transform torchPos;
    public LayerMask playerLayer;

    private bool playerNear = false;
    private float detectionRange = 5f;

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
    }

    private void Ignite() {
        currentState = lightState.ignited;
    }

    private void LightUp() {
        currentState = lightState.on;
    }

    private void Scan() {
        if (currentState != lightState.on) {
            playerNear = Physics.CheckSphere(torchPos.position, detectionRange, playerLayer);  
            
            if (playerNear) {
            HandleLighting();
            Debug.Log("Player is near torch " + ID + "Light: " + currentState);
            }  
        }
    }

    private void HandleLighting() {
        if (currentState == lightState.ignited) {
            LightUp();
        }
    }

    private Torch FindNextTorch() {
        Torch[] allTorches = FindObjectsByType<Torch>(FindObjectsSortMode.None);
        foreach (Torch torch in allTorches) {
            if (torch.ID == this.ID + 1) {
                return torch;
            }
        }
        return null;
    }
}
