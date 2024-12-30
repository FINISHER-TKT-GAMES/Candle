using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class RestPoint : MonoBehaviour {

    [SerializeField] public float restTime;    
    [SerializeField] public LayerMask playerLayer;

    private bool playerNear = false;
    private bool timerRunning = false;
    private bool obstacleUnlocked = false;

    void Start() {
        Debug.Log("Obstacle unlocked: " + obstacleUnlocked);
    }

    void Update() {

        Scan();

        if (playerNear && !timerRunning) {
            StartCoroutine(RestTimer());
            Debug.Log("Timer started");
        } else if (!playerNear && timerRunning) {
            StopAllCoroutines();
            timerRunning = false;
        }
    }

    private void Scan() {
        playerNear = Physics.CheckSphere(transform.position, wck.restpoint.detectionRange, playerLayer);  
    }

    private IEnumerator RestTimer() {
        timerRunning = true;
        while (wck.player.timeSpent < restTime) {
            yield return new WaitForSeconds(1);
            wck.player.timeSpent++;
            Debug.Log("Time spent: " + wck.player.timeSpent); // DEBUG
        }
        obstacleUnlocked = true;
        Debug.Log("Unlocked obstacle");
    }

}
