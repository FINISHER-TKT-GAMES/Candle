using System.Collections;
using UnityEngine;

// This class is used to manage the movement of the character
public class PlayerMovement : MonoBehaviour {

    [Header("Paramètres")]
    public Transform cam;
    public CharacterController controller;
    public Transform character;

    [Header("Détection du sol")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField]
    private PlayerManager player;

    void Start() {
        SetCursor();
    }

    void Update() {
        Movement();
        SlowMovement(0.5f);
        Rotate();
        Gravity();
        Jump();
        if (player.data.isGrounded && player.data.velocity.y < 0) {
            player.data.velocity.y = 0;
            player.data.gravity = -18;
        }
    }

    // Mouvements du joueur relatif à la rotation de la caméra
    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = cam.forward;
        Vector3 cameraRight = cam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        player.data.move = cameraForward * z + cameraRight * x;
        controller.Move((player.data.Speed + player.data.momentum) * Time.deltaTime * player.data.move);
    }

    private void Gravity() {
        player.data.isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        player.data.velocity.y += player.data.gravity * Time.deltaTime;
        controller.Move(player.data.velocity * Time.deltaTime);

        if (player.data.isGrounded == false) {
            StartCoroutine(GravityAcc());
        }
    }

    // Fonction de saut du joueur
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && player.data.isGrounded) {
            player.data.isJumping = true;
            AddMomentum();
        player.data.velocity.y = Mathf.Sqrt(player.data.jumpHeight * -2f * player.data.gravity);
        } else {
            player.data.isJumping = false;
        }
    }

    private IEnumerator GravityAcc() {
        while (player.data.isGrounded == false) {
            yield return new WaitForSeconds(0.3f);
            player.data.gravity -= 0.05f;
        }
    }

    // Ajoute de l'accélération au joueur
    private void AddMomentum() {
        player.data.momentum = player.data.speedBoost;
        StartCoroutine(Momentum());
    }

    // Gère l'accélération du joueur au fil du temps
    private IEnumerator Momentum() {
            while (player.data.momentum >= 1) {
            yield return new WaitForSeconds(0.05f);
            player.data.momentum -= player.data.momentumDecay;
            }
    }

    // Rotation du modèle du joueur
    private void Flip(int speed) {
        player.data.rotation = Quaternion.LookRotation(player.data.move, Vector3.up);
        character.rotation = Quaternion.RotateTowards(character.rotation, player.data.rotation, speed * Time.deltaTime);
    }

    // Logique de rotation du joueur
    private void Rotate() {
        if (player.data.move != Vector3.zero) {
            if (character.rotation == Quaternion.Inverse(player.data.rotation)) {
                Flip(player.data.sharpSpeed);
            }
            else {
                Flip(player.data.smoothSpeed);
            }
        }
    }

    private void SlowMovement(float multiplier) {
        if (Input.GetKey(KeyCode.LeftShift)) {
            player.data.Speed = player.data.DefaultSpeed * multiplier;
        } else {
            player.data.Speed = player.data.DefaultSpeed;
        }
    }

     // Lock le curseur sur la fenêtre du jeu
    private void SetCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
