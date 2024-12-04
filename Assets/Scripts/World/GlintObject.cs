using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlintObject : MonoBehaviour {

    private const float STAY_TIME = 5f;

    private bool isPlayerNear;
    private bool isTimerRunning;
    private float timeLeft;

    public Transform player;
    public LayerMask objectLayer;

    void Start() {
        StartTimer();
    }

    void Update() {

        CheckAround();

         if (isPlayerNear && timeLeft <= 0) {
            Glint();
        }
    }

    private void Glint() {
        isTimerRunning = false;
    }

    private void CheckAround() {
         if (Physics.CheckSphere(player.position, 3f, objectLayer)) {
            isPlayerNear = true;
            Debug.Log("Player is around");
         }
    }

    private void StartTimer() {
        StartCoroutine(Time(STAY_TIME));
    }

    public IEnumerator Time(float time) {
        isTimerRunning = true;
        timeLeft = time;

        while (timeLeft >= 0) {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
