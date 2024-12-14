using UnityEngine;

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

    public float waxWeight; // Taux de cire acculmulé par le joeur
    public float waxMin; // Taux de cire minimum
    public float waxMax; // Taux de cire maximum

    // Enigme de l'envie
    public int currentTorch; // ID de la dernière torche activée
    public int torchCount; // Nombre de torches activées
    public int torchMax; // Nombre de torches à activer

    // Enigme de la gourmandise
    //
}

public struct torch {
    public float detectionRange; // Rayon de détection du joueur autour d'une torche
    public float lowIntensity; // Intensité lumineuse basse
    public float highIntensity; // Intensité lumineuse haute
}


public class wck : MonoBehaviour {

    public static player player;
    public static torch torch;

    public static void Init() {

        // Player
        player.sharpSpeed = 6000;
        player.smoothSpeed = 400;
        player.playerSpeed = 10;

        player.jumpHeight = 1.4f;
        player.gravity = -9.81f;
        player.isGrounded = false;

        player.speedBoost = 8;
        player.momentum = 0;

        player.waxMax = 30;
        player.waxMin = 5;
        player.waxWeight = 10;

        player.currentTorch = 0;
        player.torchCount = 0;
        player.torchMax = 3;

        // Torches
        torch.detectionRange = 5f;
        torch.lowIntensity = 0.20f;
        torch.highIntensity = 1.0f;
    }

    void Start() {
        Init();
    }
}
