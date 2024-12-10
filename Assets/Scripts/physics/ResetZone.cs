using UnityEngine;

public class ResetZone : MonoBehaviour
{
    //on trigger enter, reset the player to is original state
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
           // reset the cristal light
            CristalLightUp cristal = other.GetComponent<CristalLightUp>();
            if (cristal != null)
            {
                Light cristalLight = cristal.GetComponentInChildren<Light>();
                cristalLight.intensity = 0;
                cristalLight.enabled = false;
            }



        }
    }
}
