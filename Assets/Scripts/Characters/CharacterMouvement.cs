using UnityEngine;

// This class is used to manage the movement of the character
public class CharacterMouvement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // we use the keyboard and the mouse for the player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // we create a vector3 to store the movement of the player
        Vector3 mouvement = new Vector3(horizontal, 0.0f, vertical);

        // we move the player
        transform.Translate(mouvement * Time.deltaTime * 5, Space.World);

        // we rotate the player
        if (mouvement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(mouvement);
        }

        

    }
}
