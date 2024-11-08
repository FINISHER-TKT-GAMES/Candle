using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windStrength = 1.0f; // Intensité du vent
    public Vector3 windDirection = Vector3.left; // Direction du vent

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que CoolCandle a bien le tag "Candle"
        {
            CoolCandle candle = other.GetComponent<CoolCandle>();
            if (candle != null)
            {
                Debug.Log("Candle est entrée dans la zone de vent.");
                candle.ApplyWind(windDirection * windStrength);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoolCandle candle = other.GetComponent<CoolCandle>();
            if (candle != null)
            {
                Debug.Log("Candle est sortie de la zone de vent.");
                candle.StopWind();
            }
        }
    }
}
