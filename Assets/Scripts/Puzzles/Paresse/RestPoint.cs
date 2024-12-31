using UnityEngine;
using System.Collections;

public class RestPoint : MonoBehaviour {

    public Engine engine;

    // Paramètres du point de repos
    [SerializeField] public float restTime;    
    [SerializeField] public GameObject linkedObstacle;
    [SerializeField] public LayerMask playerLayer;

    private bool playerNear = false;
    private bool timerRunning = false;


    void Update() {
        // Lance le timer si le joueur est proche, et le coupe si il s'éloigne
        if (playerNear && !timerRunning) {
            StartCoroutine(StartTimer());
        } else if (!playerNear && timerRunning) {
            StopTimer();
        }
        playerNear = engine.Scan(wck.restpoint.detectionRange, playerLayer);
    }

    // Compte le temps que le joueur passe à côté du point de repos
    private IEnumerator StartTimer() {
        timerRunning = true;
        while (wck.player.timeSpent < restTime) {
            yield return new WaitForSeconds(1);
            wck.player.timeSpent++;
            Debug.Log("Time spent: " + wck.player.timeSpent); // DEBUG
        }
        timerRunning = false;
        UnlockObstacle();
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
