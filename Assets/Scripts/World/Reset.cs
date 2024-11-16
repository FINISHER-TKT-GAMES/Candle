using System.Collections;
using UnityEngine;

public class Reset : MonoBehaviour {

    public const float timeBeforeReset = 5; // En secondes

    public bool isTimerRunning;
    public bool win; // Variable provisoire


    void Start() {
        // Démarre le timer en tâche de fond
        StartCoroutine(Time(timeBeforeReset));
    }

    void Update() {
        // Vérifie l'objectif de victoire
        CheckObjective(win);
    }


    // Attend [time] secondes et ensuite reset le monde
    public IEnumerator Time(float time) {
        isTimerRunning = true;
        float timeElapsed = 0f;

        while (timeElapsed < time) {
            PrintTime(timeElapsed);
            yield return new WaitForSeconds(1f);
            timeElapsed++;
        }
        ResetWorld();
    }

    // Arrête le timer
    public void StopTime() {
        isTimerRunning = false;
        StopAllCoroutines();
    }

    // Fonction pour reset le monde une fois la boucle terminée
    private void ResetWorld() {
        Debug.Log("Reset!");
        StopTime();
    }

    // Arrête le timer si l'objectif défini est atteint
    private void CheckObjective(bool objective) {
        if (isTimerRunning && objective) {
            StopTime();
        }
    }

    // Affiche le temps restant avant le reset
    private void PrintTime(float time) {
        float timeLeft = timeBeforeReset - time;
        Debug.Log("Time left: " + timeLeft + "s");
    }
}
