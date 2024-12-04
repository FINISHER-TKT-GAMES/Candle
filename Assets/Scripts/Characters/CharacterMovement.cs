using UnityEngine;
using UnityEngine.UIElements;

// This class is used to manage the movement of the character
public class CharacterMovement : MonoBehaviour {

    public Transform Cam;
    public CharacterController Controller;
    public Transform Character;
    public Rigidbody Player;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private Vector3 move;
    private Quaternion rotation;

    private int sharpSpeed = 6000;
    private int smoothSpeed = 400;

    private float playerSpeed = 10;
    private float jumpHeight = 10;
    [SerializeField] private bool isGrounded;

    void Start() {
        SetCursor();
    }

    void Update() {
        
        Movement();
        Rotate();

        Gravity();
    }

    
    // Movements du joueur relatif à la rotation de la caméra
    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = Cam.forward;
        Vector3 cameraRight = Cam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        move = cameraForward * z + cameraRight * x;
        Controller.Move(playerSpeed * Time.deltaTime * move);
    }

    private void Gravity() {
        isGrounded = Physics.CheckSphere(GroundCheck.position, 0.3f, GroundLayer);
    }

    // Rotation du modèle du joueur
    private void Flip(int speed) {
        rotation = Quaternion.LookRotation(move, Vector3.up);
        Character.rotation = Quaternion.RotateTowards(Character.rotation, rotation, speed * Time.deltaTime);
    }

    // Logique de rotation du joueur
    private void Rotate() {
        if (move != Vector3.zero) {
            if (Character.rotation == Quaternion.Inverse(rotation)) {
                Flip(sharpSpeed);
            }
            else {
                Flip(smoothSpeed);
            }
        }
    }

    private void SetCursor() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
