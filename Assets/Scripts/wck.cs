using UnityEngine;

public struct engine {
    public LayerMask playerLayer; // Layer utilisée pour la détection du joueur
}

public struct world {
    public float resetTime; // Temps d'une boucle
    public float timeLeft; // Temps restant avant Reset de l'univers
}

public struct controls {
    public KeyCode interact; // Touche pour intéragir avec les éléments du jeu
    public KeyCode burnFaster; // Touche utilisée pour que la bougie se consume plus vite
}

public enum SpeedState {normal, boost}
public enum Obstacle {door, wall};

public struct player {

    // Général
    public int sharpSpeed; // Rotation du modèle en direction opposée
    public int smoothSpeed; // Rotation du modèle normal
    public float playerSpeed; // Vitesse de déplacements

    public float jumpHeight; // Hauteur de saut
    public float gravity; // Gravité subit par le joueur
    public bool isGrounded; // Définit si le joueur est sur le sol

    public float speedBoost; // Accélération ajoutée lors d'un saut
    public float momentum; // Accélération du joueur
    public float momentumDecay; // Vitesse de déccélération

    public float reach; // Distance max d'intéraction avec des éléments du jeu

    public float wax; // Taux de cire acculmulé par le joueur
    public float waxMin; // Taux de cire minimum
    public float waxMax; // Taux de cire maximum

    public float waxDefaultSpeed; // Vitesse de perte de la cire par défaut
    public float waxSpeed; // Vitesse de perte de la cire
    public SpeedState waxSpeedState;
    public float waxDecay; // Taux de perte de la cire

    // Enigme de l'envie
    public int currentTorch; // ID de la dernière torche activée
    public int torchCount; // Nombre de torches activées
    public int torchMax; // Nombre de torches à activer

    // Enigme de la gourmandise
    public float timeSpent;
}

public struct torch {
    public float detectionRange; // Rayon de détection du joueur autour d'une torche
    public float lowIntensity; // Intensité lumineuse basse
    public float highIntensity; // Intensité lumineuse haute
}

public struct bridge {
    public float weightLimit; // Limite de poids supportable par le pont
}

public struct restpoint {
    public float detectionRange;
}


public class wck : MonoBehaviour {

    public static engine engine;
    public static world world;
    public static controls ctrl;
    public static player player;
    public static torch torch;
    public static bridge bridge;
    public static restpoint restpoint;

    public static void Init() {

        // Engine
        engine.playerLayer = LayerMask.NameToLayer("Player");

        // World
        world.resetTime = 30; // En secondes

        // Controls
        ctrl.interact = KeyCode.E;
        ctrl.interact = KeyCode.R;

        player.sharpSpeed = 6000;
        player.smoothSpeed = 400;
        player.playerSpeed = 10;

        player.jumpHeight = 1.4f;
        player.gravity = -9.81f;
        player.isGrounded = false;

        player.speedBoost = 8;
        player.momentum = 0;
        player.momentumDecay = 1;

        player.reach = 10f;

        player.waxMax = 30;
        player.waxMin = 5;
        player.wax = 30;
        player.waxDefaultSpeed = 3;
        player.waxSpeed = player.waxDefaultSpeed;
        player.waxSpeedState = SpeedState.normal;
        player.waxDecay = 0.1f;

        player.currentTorch = 0;
        player.torchCount = 0;
        player.torchMax = 3;

        player.timeSpent = 0;

        // Torches
        torch.detectionRange = 5f;
        torch.lowIntensity = 0.20f;
        torch.highIntensity = 1.0f;

        // Bridge
        bridge.weightLimit = player.waxMax-5;

        // Rest points
        restpoint.detectionRange = 8f;
    }

    void Start() {
        Init();
    }
}
