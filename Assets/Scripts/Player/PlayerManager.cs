using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance { get; private set; }

    public string currentState;

    public PlayerMovement playerMovement;

    public PlayerClimbing playerClimbing;
    public PlayerData data;

    public Reset reset;

    public void Start() {
        playerMovement.enabled = false;
        playerClimbing.enabled = false;

        ChangeState("playing");
    }

    public void Die() {
        // PLUS TARD, ON POURRA AJOUTER UN SCREEN DE MORT ICI..
        reset.ResetWorld();
    }

    public void ChangeState(string newState) {
        if (newState != currentState) {
            switch (currentState)
            {
                case "playing":
                    playerMovement.enabled = false;
                    break;
                case "climbing":
                    playerClimbing.enabled = false;
                    break;
                default:
                    break;
            }
            // Change Animation
            currentState = newState;
            switch (currentState) {
                case "playing":
                    playerMovement.enabled = true;
                    break;
                case "climbing":
                    playerClimbing.enabled = true;
                    break;
            }
        }
    }
}
