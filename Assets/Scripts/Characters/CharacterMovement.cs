using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

// This class is used to manage the movement of the character
public class CharacterMovement : MonoBehaviour {

    public Transform cam;
    public CharacterController controller;
    public Transform character;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Vector3 move;
    private Quaternion rotation;
    private Vector3 velocity;

    private bool isGrounded;

    void Start() {
        SetCursor();
    }

    void Update() {
        Movement();
        Rotate();
        Gravity();
        Jump();
    }

    // Movements du joueur relatif à la rotation de la caméra
    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = cam.forward;
        Vector3 cameraRight = cam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        move = cameraForward * z + cameraRight * x;
        controller.Move((wck.player.playerSpeed + wck.player.momentum) * Time.deltaTime * move);
    }

    private void Gravity() {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        velocity.y += wck.player.gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Fonction de saut du joueur
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            AddMomentum();
        velocity.y = Mathf.Sqrt(wck.player.jumpHeight * -2f * wck.player.gravity);
        }
    }

    // Ajoute de l'accélération au joueur
    private void AddMomentum() {
        wck.player.momentum = wck.player.speedBoost;
        StartCoroutine(Momentum());
    }

    // Gère l'accélération du joueur au fil du temps
    private IEnumerator Momentum() {
            while (wck.player.momentum >= 1) {
            yield return new WaitForSeconds(0.05f);
            wck.player.momentum--;
            }
    }

    // Rotation du modèle du joueur
    private void Flip(int speed) {
        rotation = Quaternion.LookRotation(move, Vector3.up);
        character.rotation = Quaternion.RotateTowards(character.rotation, rotation, speed * Time.deltaTime);
    }

    // Logique de rotation du joueur
    private void Rotate() {
        if (move != Vector3.zero) {
            if (character.rotation == Quaternion.Inverse(rotation)) {
                Flip(wck.player.sharpSpeed);
            }
            else {
                Flip(wck.player.smoothSpeed);
            }
        }
    }

     // Lock le curseur sur la fenêtre du jeu
    private void SetCursor() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
