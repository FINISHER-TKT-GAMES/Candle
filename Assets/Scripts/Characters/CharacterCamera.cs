using UnityEngine;

// This class is used to manage the camera of the character using the mouse and the cinemachine asset
public class CharacterCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;

    public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    private void Update() {
        
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // we use the mouse to move the camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // we rotate the camera
        transform.Rotate(-mouseY, mouseX, 0.0f);
        
    }
}
