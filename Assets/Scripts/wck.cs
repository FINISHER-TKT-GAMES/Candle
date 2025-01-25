using UnityEngine;

public struct Object {
    public LayerMask playerLayer; // Layer utilisée pour la détection du joueur
}

public struct World {
    public float resetTime; // Temps d'une boucle
    public float timeLeft; // Temps restant avant Reset de l'univers
}

public struct Controls {
    public KeyCode interact; // Touche pour intéragir avec les éléments du jeu
    public KeyCode burnFaster; // Touche utilisée pour que la bougie se consume plus vite
    public KeyCode slow; // Touche pour ralentir les mouvements du joueur
    public KeyCode bend; // Touche pour s'incliner
}

public enum SpeedState {normal, boost}
public enum Obstacle {door, wall};

public struct TorchObject {
    public float detectionRange; // Rayon de détection du joueur autour d'une torche
    public float lowIntensity; // Intensité lumineuse basse
    public float highIntensity; // Intensité lumineuse haute
}

public struct BridgeObject {
    public float weightLimit; // Limite de poids supportable par le pont
}

public struct RestpointObject {
    public float detectionRange;
}

public struct WaxObject {
    public float detectionRange;
    public float addAmount;
}

public struct StatueObject {
    public float lightIncrease;
}


public class wck : MonoBehaviour {

    public static Object engine;
    public static World world;
    public static Controls ctrl;
    public static TorchObject torch;
    public static WaxObject waxpile;
    public static BridgeObject bridge;
    public static RestpointObject restpoint;
    public static StatueObject statue;
    

    public static void Init() {

        // Engine
        engine.playerLayer = LayerMask.NameToLayer("Player");

        // World
        world.resetTime = 30; // En secondes

        // Controls
        ctrl.interact = KeyCode.E;
        ctrl.burnFaster = KeyCode.R;
        ctrl.slow = KeyCode.LeftShift;
        ctrl.bend = KeyCode.C;

        // Torches
        torch.detectionRange = 2f;
        torch.lowIntensity = 0.5f;
        torch.highIntensity = 5.0f;

        // Wax
        waxpile.detectionRange = 4.5f;
        waxpile.addAmount = 2;

        // Bridge
        bridge.weightLimit = 25;

        // Rest points
        restpoint.detectionRange = 1.5f;

        // Statues
        statue.lightIncrease = 1;
    }

    void Start() {
        Init();
    }
}
