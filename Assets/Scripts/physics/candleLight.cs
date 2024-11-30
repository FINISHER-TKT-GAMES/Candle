using UnityEngine;

public class CandleLight : MonoBehaviour
{
    public Light flameLight;
    public float burnRate = 0.1f; // Vitesse de réduction de la lumière
    public float minIntensity = 0.2f; // Intensité minimale de la lumière

    void Update()
    {
        if (flameLight != null)
        {
            flameLight.intensity = Mathf.Max(minIntensity, flameLight.intensity - burnRate * Time.deltaTime);
        }
    }

    public void Extinguish()
    {
        if (flameLight != null)
        {
            flameLight.enabled = false;
        }
    }

    public void RestoreLight(float amount)
    {
        if (flameLight != null)
        {
            flameLight.intensity += amount;
        }
    }
}
