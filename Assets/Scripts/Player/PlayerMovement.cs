using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

// This class is used to manage the movement of the character
public class PlayerMovement : MonoBehaviour
{
    [Header("Paramètres")]
    public Transform cam;
    public CharacterController controller;
    public Transform character;
    public CinemachineCamera camMachine; // Remplacement ici
    public CinemachineOrbitalFollow cinemachineOrbitalFollow;
    public CinemachineDeoccluder cinemachineDeoccluder;
    public LayerMask cameraCollisionMask;

    [Header("Caméra")]
    public float minCameraDistance = 0.5f;
    public float maxCameraDistance = 2f;
    public float cameraCollisionOffset = 0.1f;

    [Header("Détection du sol")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Flamme")]
    public Transform flame;
    public Vector3 defaultPos;
    public Vector3 bendPos;

    [SerializeField]
    private PlayerManager player;

    void Start()
    {
        SetCursor();
        player.data.movementState = PlayerData.MovementState.walking;
        ConfigureCinemachineCollision();
    }

    private void OnEnable()
    {
        // Removed CheckCameraCollision call
    }

    void Update()
    {
        Movement();
        Sneak(0.5f);
        Rotate();
        Gravity();
        Jump();
        Bend();
        // Removed CheckCameraCollision call
    }

    private void Movement()
    {
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

    private void Gravity()
    {
        player.data.isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (!player.data.isGrounded)
        {
            player.data.velocity.y += player.data.gravity * Time.deltaTime;

            if (player.data.velocity.y < 0)
            {
                StartCoroutine(GravityAcc());
            }
        }

        controller.Move(player.data.velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && player.data.isGrounded)
        {
            player.data.isJumping = true;
            player.data.velocity.y = Mathf.Sqrt(player.data.jumpHeight * -2f * player.data.gravity);
        }
        else
        {
            player.data.isJumping = false;
        }
        if (player.data.isGrounded)
        {
            player.data.gravity = -18;
        }
    }

    private IEnumerator GravityAcc()
    {
        float gravity_boost = 1f;
        while (!player.data.isGrounded && player.data.velocity.y < 0)
        {
            player.data.gravity -= gravity_boost;
            gravity_boost += 1.3f;
            if (player.data.gravity < -60)
            {
                player.data.gravity = -60;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void AddMomentum()
    {
        player.data.momentum = player.data.speedBoost;
        StartCoroutine(Momentum());
    }

    private IEnumerator Momentum()
    {
        while (player.data.momentum >= 1)
        {
            yield return new WaitForSeconds(0.05f);
            player.data.momentum -= player.data.momentumDecay;
        }
    }

    private void Flip(int speed)
    {
        player.data.rotation = Quaternion.LookRotation(player.data.move, Vector3.up);
        character.rotation = Quaternion.RotateTowards(character.rotation, player.data.rotation, speed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (player.data.move != Vector3.zero)
        {
            if (character.rotation == Quaternion.Inverse(player.data.rotation))
            {
                Flip(player.data.sharpSpeed);
            }
            else
            {
                Flip(player.data.smoothSpeed);
            }
        }
    }

    private void Sneak(float multiplier)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.data.Speed = player.data.DefaultSpeed * multiplier;
        }
        else
        {
            player.data.Speed = player.data.DefaultSpeed;
        }
    }

    private void Bend()
    {
        if (Input.GetKey(KeyCode.C))
        {
            player.data.movementState = PlayerData.MovementState.bending;
            flame.position = bendPos;
        }
        else
        {
            flame.position = defaultPos;
            player.data.movementState = PlayerData.MovementState.walking;
        }
    }

    private void SetCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    private void ConfigureCinemachineCollision()
    {

        // Configurer la détection de collision
        cinemachineDeoccluder.CollideAgainst = cameraCollisionMask;
        cinemachineDeoccluder.AvoidObstacles.CameraRadius = 0.1f;
        cinemachineDeoccluder.MinimumDistanceFromTarget = minCameraDistance;
        cinemachineDeoccluder.AvoidObstacles.Strategy = CinemachineDeoccluder.ObstacleAvoidance.ResolutionStrategy.PullCameraForward;
        cinemachineDeoccluder.AvoidObstacles.MaximumEffort = 10;
        cinemachineDeoccluder.AvoidObstacles.SmoothingTime = 0.1f;

        // Définir les distances par défaut pour chaque orbite
        SetDefaultCameraDistance();
    }

    private void SetDefaultCameraDistance()
    {
        cinemachineOrbitalFollow.Orbits.Top.Radius = maxCameraDistance;
        cinemachineOrbitalFollow.Orbits.Center.Radius = maxCameraDistance;
        cinemachineOrbitalFollow.Orbits.Bottom.Radius = maxCameraDistance;
    }
}
