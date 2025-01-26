using System.Collections;
using UnityEngine;

public class Burn : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    public GameObject fire;

    public int burnTime;
    private int burningTime = 0;


    public void OnTriggerStay(Collider @object) {
        if (@object.CompareTag("Player") && player.data.movementState == PlayerData.MovementState.bending) {
            StartCoroutine(StartBurn());
        }
    }

    private IEnumerator StartBurn() {
        while (burningTime < burnTime) {
            fire.SetActive(true);
            yield return new WaitForSeconds(1);
            burningTime++;
        }
        Debug.Log("Burning object");
        fire.SetActive(false);
        Destroy(gameObject);
    }
}
