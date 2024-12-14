using UnityEngine;

public class End : MonoBehaviour {

    public GameObject EndScene;

    // Débloque la zone finale du puzzle
    public void Unlock() {
        EndScene.SetActive(true);
    }
}
