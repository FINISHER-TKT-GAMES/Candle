using UnityEngine;

public class Interact : MonoBehaviour {

    public Engine engine;
    public Wax wax;

    public LayerMask playerLayer;

    [SerializeField] private float stock;
    [SerializeField] private bool playerNear;

    void Update() {
        playerNear = engine.Scan(wck.waxpile.detectionRange, playerLayer);
        if (playerNear) {
            // Display text "E to pickup wax"
            if (Input.GetKeyDown(wck.ctrl.interact)) {
              Pickup();  
            }
        }
    }

    private void Pickup() {
        if (stock >= wck.waxpile.addAmount) {
            stock -= wck.waxpile.addAmount;
            wax.PickupWax(wck.waxpile.addAmount);
        } else if (stock < wck.waxpile.addAmount) {
            wax.PickupWax(stock);
        } else {
            Debug.Log("No more wax inside this pile");
        }
    }
}
