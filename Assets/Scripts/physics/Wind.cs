using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windStrength = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Un objet est entré dans la zone de vent : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est détecté dans la zone de vent.");
            CandleLight candle = other.GetComponent<CandleLight>();

            if (candle != null)
            {
                Debug.Log("Le script CandleLight a été trouvé. Appliquer l'effet du vent.");
                candle.flameLight.intensity -= windStrength;
                // deplacer la spot light dans la direction des particules de vent
                candle.flameLight.transform.position += transform.forward * 1;
            }
            else
            {
                Debug.LogWarning("Le joueur n'a pas de script CandleLight !");
            }
        }
        else
        {
            Debug.Log("L'objet n'est pas tagué Player.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a quitté la zone de vent.");
        }
    }
}
