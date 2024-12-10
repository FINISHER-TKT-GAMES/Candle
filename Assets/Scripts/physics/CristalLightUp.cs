using UnityEngine;
using System.Collections;
using System.Drawing;
using UnityEngine.Experimental.GlobalIllumination;
public class CristalLightUp : MonoBehaviour
{
    //when the player enters the trigger, light up progressively the cristal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");

            StartCoroutine(LightUpCristal());
        }
    }

    // acces the point light component and increase the intensity over time

    private IEnumerator LightUpCristal()
    {
        Light cristalLight = GetComponentInChildren<Light>();
        float targetIntensity = 10f;
        float timeToLightUp = 5f;
        float t = 0f;
        cristalLight.enabled = true;
        while (t < 1)
        {
            t += Time.deltaTime / timeToLightUp;
            cristalLight.intensity = Mathf.Lerp(0, targetIntensity, t);
            yield return null;
        }
    }
}
