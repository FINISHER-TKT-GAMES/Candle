using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class RestPoint : MonoBehaviour {

    [SerializeField] public float restTime;    
    [SerializeField] public GameObject linkedObstacle;

    private bool playerNear = false;
    private bool timerRunning = false;
    private bool obstacleUnlocked = false;

    void Start() {
        Debug.Log("Obstacle unlocked: " + obstacleUnlocked); // DEBUG
    }

    void Update() {

        Scan();

        if (playerNear && !timerRunning) {
            StartCoroutine(RestTimer());
            Debug.Log("Timer started"); // DEBUG
        } else if (!playerNear && timerRunning) {
            StopAllCoroutines();
            timerRunning = false;
        }
    }

    private void Scan() {
        playerNear = Physics.CheckSphere(transform.position, wck.restpoint.detectionRange, wck.engine.playerLayer);  
    }

    private IEnumerator RestTimer() {
        timerRunning = true;
        while (wck.player.timeSpent < restTime) {
            yield return new WaitForSeconds(1);
            wck.player.timeSpent++;
            Debug.Log("Time spent: " + wck.player.timeSpent); // DEBUG
        }
        timerRunning = false;
        obstacleUnlocked = true;
        Debug.Log("Unlocked obstacle"); // DEBUG
        UnlockObstacle();
    }

    private void UnlockObstacle() {
        linkedObstacle.SetActive(false);
    }
}
