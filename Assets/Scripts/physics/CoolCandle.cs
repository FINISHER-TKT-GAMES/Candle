using UnityEngine;

public class CoolCandle : MonoBehaviour
{
    private Light flameLight;
    private Vector3 initialLightPosition;

    void Start()
    {
        flameLight = GetComponentInChildren<Light>();
        initialLightPosition = flameLight.transform.localPosition;
        Debug.Log("Initialisation de la bougie terminée.");
    }

    public void ApplyWind(Vector3 windForce)
    {
        if (flameLight != null)
        {
            flameLight.transform.localPosition = initialLightPosition + (Vector3)windForce * 0.5f;
            flameLight.intensity = Mathf.Clamp(flameLight.intensity - 0.1f, 0, 1);
            Debug.Log("Vent appliqué sur la bougie : Position de la flamme décalée et intensité réduite.");
        }
    }

    public void StopWind()
    {
        if (flameLight != null)
        {
            flameLight.transform.localPosition = initialLightPosition;
            flameLight.intensity = 1;
            Debug.Log("Vent arrêté : Position de la flamme réinitialisée et intensité restaurée.");
        }
    }
}
