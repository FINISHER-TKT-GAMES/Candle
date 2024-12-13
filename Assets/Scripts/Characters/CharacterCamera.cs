using UnityEngine;

public class CharacterCamera : MonoBehaviour {
    [Header("References")]
    public Transform orientation;
    public Transform player;

    public float rotationSpeed;

    void Start() {
        SetCursor();
    }

    void Update() {
        
        // Rotation de l'orientation de la Camera
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // Définition des inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotation de la Camera en fonction des inputs
        transform.Rotate(-mouseY, mouseX, 0.0f);
        
    }

        // Lock le curseur sur la fenêtre du jeu
    private void SetCursor() {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
