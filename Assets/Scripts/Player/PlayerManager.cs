using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance { get; private set; }

    private string currentState;

    public PlayerMovement playerMovement;
    public PlayerData data;

    public void Init() {
        ChangeState("playing");
    }

    public void ChangeState(string newState) {
        if (newState != currentState) {
            switch (currentState)
            {
                case "playing":
                    //_inputScript.enabled = false;
                    playerMovement.enabled = false;
                    //_collisionScript.enabled = false;
                    break;
                case "respawnLastCP":
                    //_respawnLastCP.enabled = false;
                    break;
                default:
                    break;
            }
            // Change Animation
            currentState = newState;
        }
    }

    void Update() {
        switch (currentState) {
            case "playing":
                playerMovement.enabled = true;
                break;
        }
    }
}
