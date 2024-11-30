using UnityEngine;

public class interaction : MonoBehaviour
{
    public bool isLit = false;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player") && !isLit)
    {
        Debug.Log("Le joueur est détecté dans la zone de vent.");
        CandleLight candle = other.GetComponent<CandleLight>();

        if (candle != null)
        {
            Debug.Log("Le script CandleLight a été trouvé. Appliquer l'effet du vent.");
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
    
}
