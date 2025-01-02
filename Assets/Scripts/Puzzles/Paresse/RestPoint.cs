using UnityEngine;
using System.Collections;

public class RestPoint : MonoBehaviour {

    public Engine engine;

    // Paramètres du point de repos
    [SerializeField] public float restTime;    
    [SerializeField] public GameObject linkedObstacle;
    [SerializeField] public LayerMask playerLayer;

    [SerializeField] private bool playerNear = false;
    [SerializeField] private bool timerRunning = false;


    void Update() {
        playerNear = engine.Scan(wck.restpoint.detectionRange, playerLayer);
        // Lance le timer si le joueur est proche, et le coupe si il s'éloigne
        if (playerNear && !timerRunning) {
            StartCoroutine(StartTimer());
        } else if (!playerNear && timerRunning) {
            Debug.Log("Player went too far away");
            StopTimer();
        }
    }

    // Compte le temps que le joueur passe à côté du point de repos
    private IEnumerator StartTimer() {
        timerRunning = true;
        while (wck.player.timeSpent < restTime) {
            yield return new WaitForSeconds(1);
            wck.player.timeSpent++;
            Debug.Log("Time spent: " + wck.player.timeSpent); // DEBUG
        }
        Debug.Log("Timer over");
        timerRunning = false;
        UnlockObstacle();
        StopTimer();
    }

    private void StopTimer() {
            StopAllCoroutines();
            Debug.Log("Timer stopped");
            timerRunning = false;
            wck.player.timeSpent = 0;
    }

    // Débloque l'obstacle lié au point de repos
    private void UnlockObstacle() {
        linkedObstacle.SetActive(false);
    }
}
