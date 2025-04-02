using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

    public PlayerManager player;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Text dialogue;
    [SerializeField] private bool isDialogueRunning;

    public string[] allDialogues;
    [SerializeField] private string currentDialogue;
    [SerializeField] private int numberDialogue;

    private bool isCooldownActive;
    

    void Start() {
        CreateDialogue();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Return) && isDialogueRunning && !isCooldownActive) {
            NextDialogue();
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (player.data.isInteracting) {
        collider.gameObject.SetActive(true);
        StartInteracting();  
        }
    }


    // Créer tous les dialogues du NPC
    public void CreateDialogue() {
        allDialogues = new string[] {
            "Hello",
            "Welcome to the Village"
        };
    }

    // Lance l'intéraction avec le NPC
    private void StartInteracting() {
        isDialogueRunning = true;
        player.data.Speed = 0;
        dialogueBox.SetActive(true);
        numberDialogue = 0;
        currentDialogue = allDialogues[numberDialogue];
        dialogue.text = currentDialogue;
    }

    // Affiche le prochain dialogue
    private void NextDialogue() {
        Debug.Log("Showing next dialogue");
        StartCoroutine(CooldownDialogue(1));
        if (numberDialogue < allDialogues.Length-1) {
            numberDialogue++;
            currentDialogue = allDialogues[numberDialogue];
            dialogue.text = currentDialogue;
        }
        else {
            StopIntecracting();
        }
    }

    // Arrête l'intéraction avec le personnage
    private void StopIntecracting() {
        Debug.Log("Stopping interaction with NPC");
        isDialogueRunning = false;
        dialogueBox.SetActive(false);
        player.data.Speed = 10;
    }

    // Cooldown method to prevent spamming dialogues
    public IEnumerator CooldownDialogue(float time) {
        isCooldownActive = true;
        yield return new WaitForSeconds(time);
        isCooldownActive = false;
    }
}
