using UnityEngine;

public class ResetZoneWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CandleLight candle = other.GetComponent<CandleLight>();
            
            if (candle != null)
            {
            Debug.Log("reseting player");
                candle.flameLight.intensity = 10;
                candle.flameLight.enabled = true;
            }
        }
    }
}
