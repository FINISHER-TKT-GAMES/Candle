using Unity.VisualScripting;
using UnityEngine;

public class WaxPile : MonoBehaviour {

    [Header("Scripts")]
    public Engine engine;
    public Wax wax;

    [Header("Paramètres")]
    public LayerMask playerLayer;
    public Transform pilePos;

    [Header("Debug")]
    [SerializeField] private float stock;
    [SerializeField] private bool playerNear;


    void Update() {
        // Détecte si le joueur est proche, et si il appuie sur sa touche d'intéraction (E)
        playerNear = engine.ScanAround(pilePos.position, Game.waxpile.detectionRange, playerLayer);
        if (playerNear) {
            // FT: DISPLAY TEXT "E to pickup wax"
            if (Input.GetKeyDown(Game.ctrl.interact)) {
                Pickup();  
            }
        }
    }

    // Retire la cire de la pile et l'ajoute au joueur
    private void Pickup() {
        if (stock >= Game.waxpile.addAmount) {
            stock -= Game.waxpile.addAmount;
            wax.PickupWax(Game.waxpile.addAmount);
        } else if (stock < Game.waxpile.addAmount) {
            wax.PickupWax(stock);
        } else {
            Debug.Log("No more wax inside this pile");
        }
        if (stock <= 0) {
        Destroy(gameObject);
        }
    }
}
