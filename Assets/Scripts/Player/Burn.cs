using System.Collections;
using UnityEngine;

public class Burn : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    public int burnTime;
    private int timeSpent = 0;


    public void OnTriggerEnter(Collider @object) {
        Debug.Log("Starting to burn object");
        if (@object.CompareTag("Player") && player.data.movementState == PlayerData.MovementState.bending) {
            StartCoroutine(StartBurn());
        }
    }

    private IEnumerator StartBurn() {
        while (timeSpent < burnTime) {
            yield return new WaitForSeconds(1);
            timeSpent++;
        }
        Debug.Log("Burning object");
        Destroy(gameObject);
        // timeSpent = 0;
    }
}
