using UnityEngine;

public class ResetZoneBridge : MonoBehaviour
{
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // reset the bridge object by delete it and instantiate a new one
            Destroy(bridge);
            Instantiate(bridge, new Vector3(-3.400002f, 260.47f, 103.9f), Quaternion.identity);
        }
    }
}
