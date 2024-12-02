using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CandleLight candle = other.GetComponent<CandleLight>();
            if (candle != null)
            {
                Debug.Log("La bougie entre dans l'eau. Extinction !");
                candle.Extinguish();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CandleLight candle = other.GetComponent<CandleLight>();
        if (other.CompareTag("Player"))
        {
            Debug.Log("La bougie est sortie de l'eau.");
            
        }
    }
}
