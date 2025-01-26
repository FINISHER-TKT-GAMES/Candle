using UnityEngine;
using System.Collections;

public class RestPoint : MonoBehaviour {

    [SerializeField]
    private PlayerManager player;

    public Engine engine;

    // Paramètres du point de repos
    [Header("Paramètres")]
    [SerializeField] public float restTime;    
    [SerializeField] public GameObject linkedObstacle;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public float detectionRange;

    [Header("Debug")]
    [SerializeField] private bool playerNear = false;
    [SerializeField] private bool timerRunning = false;


    void Update() {
        playerNear = engine.ScanAround(transform.position, detectionRange, playerLayer);
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
        while (player.data.timeSpent < restTime) {
            yield return new WaitForSeconds(1);
            player.data.timeSpent++;
            Debug.Log("Time spent: " + player.data.timeSpent); // DEBUG
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
            player.data.timeSpent = 0;
    }

    // Débloque l'obstacle lié au point de repos
    private void UnlockObstacle() {
        linkedObstacle.SetActive(false);
    }
}
