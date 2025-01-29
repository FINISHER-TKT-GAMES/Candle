using Unity.Cinemachine;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{

    [Header("Paramètres")]
    public CharacterController controller;
    public Transform character;

    public PlayerManager player;

    public CinemachineOrbitalFollow camMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        camMachine.Orbits.Top.Radius = 8;
        camMachine.Orbits.Center.Radius = 8;
        camMachine.Orbits.Bottom.Radius = 8;
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 climbDirection = new Vector3(horizontalInput, verticalInput, 0);

        Vector3 climbRight = Vector3.Cross(player.data.hit.normal, Vector3.up).normalized;

        Vector3 moveDirection = (climbRight * horizontalInput + Vector3.up * verticalInput).normalized;

        controller.Move(moveDirection * player.data.climbingSpeed * Time.deltaTime);

        controller.Move(-player.data.hit.normal * 0.1f);

    }
}
