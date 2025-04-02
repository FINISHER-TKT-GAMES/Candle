using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

    public PlayerManager player;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Text dialogue;

    [SerializeField] private string characterName;
    [SerializeField] private Text textName;

    [SerializeField] private GameObject passSign;

    private bool isDialogueRunning;
    public string[] allDialogues;
    private string currentDialogue;
    private int numberDialogue;
    private int progressDialogue;

    private bool isCooldownActive;
    private IEnumerator textAnim;

    void Start() {
        textName.text = characterName;
        dialogueBox.SetActive(false);
        passSign.SetActive(false);
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && isDialogueRunning && isCooldownActive) {
            StopCoroutine(textAnim);
            dialogue.text = currentDialogue;
            isCooldownActive = false;
            passSign.SetActive(true);
            
        } else if (Input.GetKeyDown(KeyCode.Return) && isDialogueRunning && !isCooldownActive) {
            NextDialogue();
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (Input.GetKeyDown(Game.ctrl.interact) && !isDialogueRunning) { // press e
            StartInteracting();
        }
    }


    // Lance l'intéraction avec le NPC
    private void StartInteracting() {
        isDialogueRunning = true;
        player.playerMovement.enabled = false;
        player.data.velocity = Vector3.zero;
        dialogueBox.SetActive(true);
        numberDialogue = 0;
        currentDialogue = allDialogues[numberDialogue];
        StartCoroutine(textAnim = TextAnim(0.08f));
    }

    // Affiche le prochain dialogue
    private void NextDialogue() {
        if (numberDialogue < allDialogues.Length-1) {
            passSign.SetActive(false);
            numberDialogue++;
            currentDialogue = allDialogues[numberDialogue];
            StartCoroutine(textAnim = TextAnim(0.08f));
        }
        else {
            StopIntecracting();
        }
    }

    private IEnumerator TextAnim(float time) {
        progressDialogue = 0;
        while (progressDialogue < currentDialogue.Length) {
            isCooldownActive = true;
            progressDialogue++;
            dialogue.text = currentDialogue.Substring(0, progressDialogue);
            yield return new WaitForSeconds(time);
        }
        isCooldownActive = false;
        passSign.SetActive(true);
    }

    // Arrête l'intéraction avec le personnage
    private void StopIntecracting() {
        Debug.Log("Stopping interaction with NPC");
        isDialogueRunning = false;
        dialogueBox.SetActive(false);
        player.playerMovement.enabled = true;
    }
}
