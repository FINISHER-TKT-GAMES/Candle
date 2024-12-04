using UnityEngine;

public struct player {
    public int sharpSpeed;
    public int smoothSpeed;

    public float playerSpeed;
    public float jumpHeight;
    public float gravity;
}

public class wck : MonoBehaviour {

    public static player player;

    public static void Init() {
        player.sharpSpeed = 6000;
        player.smoothSpeed = 400;
        player.playerSpeed = 10;
        player.jumpHeight = 1.0f;
        player.gravity = -9.81f;
    }

    void Start() {
        Init();
    }
}
