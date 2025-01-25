using System.Collections;
using UnityEngine;

public class Burn : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    public int burnTime;
    private int burningTime = 0;


    public void OnTriggerEnter(Collider @object) {
        Debug.Log("Starting to burn object");
        if (@object.CompareTag("Player") && player.data.movementState == PlayerData.MovementState.bending) {
            StartCoroutine(StartBurn());
        }
    }

    private IEnumerator StartBurn() {
        while (burningTime < burnTime) {
            yield return new WaitForSeconds(1);
            burningTime++;
        }
        Debug.Log("Burning object");
        Destroy(gameObject);
    }
}
