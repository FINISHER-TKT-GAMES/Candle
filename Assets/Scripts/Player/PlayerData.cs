using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "Player Data")]
public class PlayerData : ScriptableObject {

    [Header("Vitesse déplacements")]
    public float DefaultSpeed; // Vitesse de déplacements par défaut
    public float Speed; // Vitesse de déplacements
    public enum MovementState {walking, sneaking, bending}
    public MovementState movementState;
    public int sharpSpeed; // Rotation du modèle en direction opposée
    public int smoothSpeed; // Rotation du modèle normal

    [Header("Gravité")]
    public float jumpHeight; // Hauteur de saut
    public float gravity; // Gravité subit par le joueur
    public bool isGrounded; // Définit si le joueur est sur le sol
    public bool isJumping; // Définit si le joueur saute

    [Header("Accélération")]
    public float speedBoost; // Accélération ajoutée lors d'un saut
    public float momentum; // Accélération du joueur
    public float momentumDecay; // Vitesse de déccélération

    [Header("Vélocité")]
    public Vector3 move;
    public Quaternion rotation;
    public Vector3 velocity;
    
    [Header("Général")]
    public float reach; // Distance max d'intéraction avec des éléments du jeu
    public float temperature; // Température du joueur

    [Header("Niveaux de cire")]
    public float wax; // Taux de cire acculmulé par le joueur
    public float waxMin; // Taux de cire minimum
    public float waxMax; // Taux de cire maximum

    [Header("Vitesse cire")]
    public float waxDefaultSpeed; // Vitesse de perte de la cire par défaut
    public float waxSpeed; // Vitesse de perte de la cire
    public SpeedState waxSpeedState;
    public float waxDecay; // Taux de perte de la cire

    [Header("Enigme de l'envie")]
    public int currentTorch; // ID de la dernière torche activée
    public int torchCount; // Nombre de torches activées
    public int torchMax; // Nombre de torches à activer

    [Header("Enigme gourmandise")]
    public float timeSpent;

    [Header("Enigme colère")]
    public int statueCount;
    public int statueMax;

    [Header("Climbing")]
    public int climbingSpeed;
    public RaycastHit hit;
}
