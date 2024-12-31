using UnityEngine;

// Fonctions réutilisables dans d'autres scripts
public class Engine : MonoBehaviour {

    // Permet de scanner autour de l'objet, avec un rayon et sur une layer spécifique
    // Renvoie true si un objet de la layer entre dans le rayon
    public bool Scan(float detectionRange, LayerMask layer) {
        return Physics.CheckSphere(transform.position, detectionRange, layer);  
    }

    // Permet de scanner autour d'un objet spécifié, avec un rayon et sur une layer spécifique
    // Renvoie true si un objet de la layer entre dans le rayon
    public bool ScanAround(Vector3 position, float detectionRange, LayerMask layer) {
        return Physics.CheckSphere(position, detectionRange, layer);  
    }

}
