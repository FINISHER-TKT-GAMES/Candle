using UnityEngine;

public class Wandering : MonoBehaviour {

    [SerializeField] private Rigidbody rb;

    void Update() {
        Vector3 velocity = rb.linearVelocity;
        velocity.x += 0.001f;
        rb.linearVelocity = velocity;
    }

}
