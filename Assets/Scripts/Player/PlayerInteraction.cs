using UnityEngine;
using Unity.Cinemachine;

public class PlayerInteraction : MonoBehaviour {

    public PlayerManager player;
    public Transform climbCheck;

    public LayerMask climbLayer;

    public Transform character;

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(character.transform.position, character.transform.forward, out player.data.hit, 2f, climbLayer)) {
            player.ChangeState("climbing");
        } 
        else {
            player.ChangeState("playing");
        }
        
    }

    void OnDrawGizmosSelected() {
        // Visualiser le raycast de d�tection du mur
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(character.transform.position, character.transform.forward * 2f);
    }

}
