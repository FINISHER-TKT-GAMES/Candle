using UnityEngine;

public class ResetZoneWind : MonoBehaviour
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
                //candle.flameLight.transform.position = new Vector3(0, 4.94f, 0);
            }
        }
    }
}
