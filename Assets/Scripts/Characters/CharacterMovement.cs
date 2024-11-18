using UnityEngine;

// This class is used to manage the movement of the character
public class CharacterMovement : MonoBehaviour {

    public float playerSpeed = 10;

    public Transform Cam;
    public CharacterController Controller;


    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = Cam.forward;
        Vector3 cameraRight = Cam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 move = cameraForward * z + cameraRight * x;
        Controller.Move(playerSpeed * Time.deltaTime * move);
    }
}
