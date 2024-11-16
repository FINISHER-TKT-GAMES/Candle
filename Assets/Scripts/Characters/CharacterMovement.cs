using UnityEngine;

// This class is used to manage the movement of the character
public class CharacterMovement : MonoBehaviour {

    public CharacterController controller;

    public float playerSpeed = 10;

    // Update is called once per frame
    void Update() {
        
        Movement();

    }

    void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(playerSpeed * Time.deltaTime * move);
    }
}
