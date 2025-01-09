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
                    playerMovement.enabled = false;
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
