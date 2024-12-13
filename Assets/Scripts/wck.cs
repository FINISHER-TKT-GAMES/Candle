using UnityEngine;

public struct player {
    public int sharpSpeed;
    public int smoothSpeed;

    public float playerSpeed;
    public float jumpHeight;
    public float gravity;

    public int currentTorch;
    public int torchCount;
    public int torchMax;
}

public struct torch {
    public float detectionRange;
    public float lowIntensity;
    public float highIntensity;
}


public class wck : MonoBehaviour {

    public static player player;
    public static torch torch;

    public static void Init() {

        // Player
        player.sharpSpeed = 6000;
        player.smoothSpeed = 400;
        player.playerSpeed = 10;

        player.jumpHeight = 1.4f;
        player.gravity = -9.81f;

        player.currentTorch = 0;
        player.torchCount = 0;
        player.torchMax = 3;

        // Torches
        torch.detectionRange = 5f;
        torch.lowIntensity = 0.20f;
        torch.highIntensity = 1.0f;
    }

    void Start() {
        Init();
    }
}
