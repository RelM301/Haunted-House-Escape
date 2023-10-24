using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogue : MonoBehaviour
{
    //Código de diálogo para los NPCs.   
    public string[] randomMessages;
    public Actor[] actors;

    public void StartRandomDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.OpenRandomDialogue(randomMessages, actors);
    }
}
