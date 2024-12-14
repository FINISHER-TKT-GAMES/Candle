using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour {

    public Text timerText;

    public bool isTimerRunning;
    public bool win; // Variable provisoire


    void Start() {
        // Démarre le timer en tâche de fond
        StartCoroutine(Time(wck.world.resetTime));
    }

    void Update() {
        // Vérifie l'objectif de victoire
        CheckObjective(win);
    }


    // Attend [time] secondes et ensuite reset le monde
    public IEnumerator Time(float time) {
        isTimerRunning = true;
        wck.world.timeLeft = time;

        while (wck.world.timeLeft >= 0) {
            yield return new WaitForSeconds(1);
            PrintTime(wck.world.timeLeft);
            wck.world.timeLeft--;
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
        SceneManager.LoadScene("test");
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
        timerText.text = "Reset dans " + time.ToString() + "s";
    }
}
