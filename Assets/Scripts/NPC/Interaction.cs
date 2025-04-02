using System;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

    public PlayerManager player;

    [SerializeField] private Collider hitbox;
    [SerializeField] private bool isPlayerNear;

    [SerializeField] private GameObject dialogue;
    [SerializeField] private Text dialogueText;

    public string[] allDialogues;
    private string currentDialogue;

    void Start() {
        CreateDialogue();
    }

    void Update() {
        if (player.data.isInteracting && isPlayerNear) {
            StartInteracting();
        }
    }
    
    private void OnTriggerStay(Collider collider) {
        isPlayerNear = true;
    }


    // Créer tous les dialogues du NPC
    public void CreateDialogue() {
        allDialogues = new string[] {
            "iii",
            "iii"
        };
    }

    // Lance l'intéraction avec le NPC
    private void StartInteracting() {
        dialogue.SetActive(true);
        currentDialogue = allDialogues[0];
    }

    // Affiche le prochain dialogue
    private void NextInteraction() {
        // TODO: DISPLAY NEXT DIALOGUE ON PLAYER CLICK
    }

    // Arrête l'intéraction avec le personnage
    private void StopIntecracting() {
        dialogue.SetActive(false);
    }
}
