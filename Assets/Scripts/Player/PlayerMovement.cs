using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;


// This class is used to manage the movement of the character
public class PlayerMovement : MonoBehaviour {

    [Header("Paramètres")]
    public Transform cam;
    public CharacterController controller;
    public Transform character;
    public CinemachineOrbitalFollow camMachine;
    public LayerMask cameraCollisionMask; // Ajouter cette ligne

    [Header("Caméra")]
    public float minCameraDistance = 1f;
    public float maxCameraDistance = 8f;
    public float cameraCollisionOffset = 0.1f; // Distance minimale entre la caméra et les obstacles

    [Header("Détection du sol")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Flamme")]
    public Transform flame;
    public Vector3 defaultPos;
    public Vector3 bendPos;

    [SerializeField]
    private PlayerManager player;

    void Start() {
        SetCursor();
        player.data.movementState = PlayerData.MovementState.walking;
    }

    private void OnEnable() {
        // SetDefaultCameraDistance();
        CheckCameraCollision();
    }

    void Update() {
        Movement();
        Sneak(0.5f);
        Rotate();
        Gravity();
        Jump();
        Bend();
        CheckCameraCollision();
        
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
        controller.Move(player.data.Speed * Time.deltaTime * player.data.move);
    }

    private void Gravity() {
        player.data.isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        player.data.velocity.y += player.data.gravity * Time.deltaTime;
        controller.Move(player.data.velocity * Time.deltaTime);

        if (player.data.isGrounded == false) {
            StartCoroutine(GravityAcc());
        }
    }

    // Fonction de saut du joueur
    private void Jump() {
        if (Input.GetKey(KeyCode.Space) && player.data.isGrounded) {
            player.data.isJumping = true;
            AddMomentum();
            player.data.velocity.y = Mathf.Sqrt(player.data.jumpHeight * -2f * player.data.gravity);
        } else {
            player.data.isJumping = false;
        }
        if (player.data.isGrounded && player.data.velocity.y < 0) {
            player.data.velocity.y = 0;
            player.data.gravity = -18;
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

    // Fonction de sneak du joueur
    private void Sneak(float multiplier) {
        if (Input.GetKey(KeyCode.LeftShift)) {
            player.data.Speed = player.data.DefaultSpeed * multiplier;
        } else {
            player.data.Speed = player.data.DefaultSpeed;
        }
    }

    // Fonction de bend du joueur
    private void Bend() {
        if (Input.GetKey(KeyCode.C)) {
            player.data.movementState = PlayerData.MovementState.bending;
            flame.position = bendPos;
        }
        else {
            flame.position = defaultPos;
            player.data.movementState = PlayerData.MovementState.walking;
        }
    }

     // Lock le curseur sur la fenêtre du jeu
    private void SetCursor() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    private void SetDefaultCameraDistance() {
        camMachine.Orbits.Top.Radius = maxCameraDistance;
        camMachine.Orbits.Center.Radius = maxCameraDistance;
        camMachine.Orbits.Bottom.Radius = maxCameraDistance;
    }

    private void CheckCameraCollision() {
        Vector3 directionToCamera = (cam.position - transform.position).normalized;
        float distanceToCamera = Vector3.Distance(transform.position, cam.position);
        
        // Démarrer le raycast un peu plus haut que le sol
        Vector3 rayStart = transform.position + Vector3.up * 0.5f;
        
        Debug.DrawRay(rayStart, directionToCamera * maxCameraDistance, Color.red);

        if (Physics.Raycast(rayStart, directionToCamera, out RaycastHit hit, maxCameraDistance, cameraCollisionMask)) {
            // Ignorer si on touche le joueur
            if (hit.collider.gameObject != gameObject) {
                float newDistance = Mathf.Clamp(hit.distance - cameraCollisionOffset, minCameraDistance, maxCameraDistance);
                camMachine.Orbits.Top.Radius = newDistance;
                camMachine.Orbits.Center.Radius = newDistance;
                camMachine.Orbits.Bottom.Radius = newDistance;
                print("Collision avec: " + hit.collider.gameObject.name);
            }
        } else {
            SetDefaultCameraDistance();
        }
    }
}
