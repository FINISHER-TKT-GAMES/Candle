using UnityEngine;

public class Water : MonoBehaviour {

    public Light flameLight;

    void OnTriggerEnter(Collider collider) {
        flameLight.intensity = 0;
        //TODO: AJOUTER FONCITON DE MORT DU JOUEUR ICI
    }

}
