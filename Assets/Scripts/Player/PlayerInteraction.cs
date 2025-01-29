using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public PlayerManager playerManager;
    public Transform climbCheck;

    public LayerMask climbLayer;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(climbCheck.position, 0.3f, climbLayer)) {
            playerManager.ChangeState("climbing");
        }
    }





}
