using UnityEngine;

public class ResetZoneCristal : MonoBehaviour
{
    //the cristalDisabled object
    public GameObject cristalDisabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // reset the cristal light
            Light cristalLight = cristalDisabled.GetComponentInChildren<Light>();
            if (cristalLight.enabled)
            {
                cristalLight.intensity = 0;
                cristalLight.enabled = false;
            }



        }
    }
}
