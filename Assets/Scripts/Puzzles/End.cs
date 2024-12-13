using UnityEngine;

public class End : MonoBehaviour {

    public GameObject EndScene;

    public void Unlock() {
        EndScene.SetActive(true);
    }
}
