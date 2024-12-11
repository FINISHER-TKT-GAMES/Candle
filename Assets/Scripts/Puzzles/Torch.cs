using UnityEngine;

public class Torch : MonoBehaviour {

    [SerializeField] private int ID;

    public Transform torchPos;
    public LayerMask playerLayer;

    private bool playerNear = false;
    private lightState currentState = lightState.off;

    private enum lightState {
        off,
        ignited,
        on
    }

    void Update() {
    }

    private void Ignite() {
    }

    private void LightUp() {
    }

    private void LightOff() {
    }

    private void Scan() {
        playerNear = Physics.CheckSphere(torchPos.position, 0.3f, playerLayer);
        if (playerNear) {
            Debug.Log($"Player is near torch " + ID);
        }
    }

    private void HandleLighting() {
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
