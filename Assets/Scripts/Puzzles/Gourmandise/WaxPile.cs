using UnityEngine;

public class WaxPile : MonoBehaviour {

    public Engine engine;
    public Wax wax;

    public LayerMask playerLayer;
    public Transform pilePos;

    [SerializeField] private float stock;
    [SerializeField] private bool playerNear;

    void Update() {
        playerNear = engine.ScanAround(pilePos.position, wck.waxpile.detectionRange, playerLayer);
        if (playerNear) {
            // Display text "E to pickup wax"
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("Pressed E");
                Pickup();  
            }
        }
    }

    private void Pickup() {
        if (stock >= wck.waxpile.addAmount) {
            stock -= wck.waxpile.addAmount;
            Debug.Log("Remove two of wax from waxpile");
            wax.PickupWax(wck.waxpile.addAmount);
            Debug.Log("Added two of wax to player");
        } else if (stock < wck.waxpile.addAmount) {
            wax.PickupWax(stock);
        } else {
            Debug.Log("No more wax inside this pile");
        }
    }
}
