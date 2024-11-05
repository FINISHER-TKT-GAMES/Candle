using UnityEngine;

// This class is used to manage the camera of the character using the mouse and the cinemachine asset
public class CharacterCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        // we use the mouse to move the camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // we rotate the camera
        transform.Rotate(-mouseY, mouseX, 0.0f);
        
         
    }
}
