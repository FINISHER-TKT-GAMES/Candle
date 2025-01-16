using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    //when a weight of + 50 units is on , move the elevator up to 10 units

    public float weightThreshold = 50f; // Poids maximum avant de bouger
    public float moveDistance = 10f; // Distance à parcourir

    public float time = 5f; // Temps avant pour monter
    


    private void OnCollisionEnter(Collision collision) {
         Rigidbody rb = collision.rigidbody;
        if (rb != null && rb.mass > weightThreshold)
        {
            Debug.Log("Elevator moving up !");
            MoveElevator();
        }
    }

    //move the elevator while the weight is on

    private void MoveElevator()
    {
        Vector3 targetPosition = transform.position + Vector3.up * moveDistance;
        StartCoroutine(MoveToPosition(targetPosition, time));
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float timeToMove)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, targetPosition, t);
            yield return null;
        }
    }

    //move the elevator position to (-32.90894,254.75,117.72) after the weight is removed and 10 seconds have passed

    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine(ResetElevatorPosition(10f));
    }
    
    private IEnumerator ResetElevatorPosition(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Vector3 targetPosition = new Vector3(-32.90894f, 254.75f, 117.72f);
        StartCoroutine(MoveToPosition(targetPosition, time));
    }

    

    
}
