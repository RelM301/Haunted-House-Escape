using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region VARIABLES

    public Text messageText;
    public RectTransform backgroundBox;
    public static bool isActive = false;

    private NPCController activeNPC; // The currently active NPC
    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;

    // Flag to track when the conversation has finished
    private bool conversationFinished = false;

    public static DialogueManager Instance { get; private set; }

    #endregion
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate DialogueManager instance found. Destroying the new one.");
            Destroy(this.gameObject);
        }
    }

    #region MANEJO DEL DIÁLOGO

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Comienza conversación mensajes cargados: " + messages.Length);
        DisplayMessage();

        // Animación of the dialogue box.
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];

        // Effect of text alpha.
        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Termina la conversación");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            FinishConversation();

            // Check if the conversation is finished before activating the quiz panel
            if (conversationFinished && activeNPC != null)
            {
                GameObject quizPanel = activeNPC.quizPanel;
                if (quizPanel != null)
                {
                    quizPanel.SetActive(true);
                }
            }
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, .5f);
    }

    #endregion

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update the message with a click.
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }

    #region DIÁLOGO RANDOM DE LOS NPCs

    public void OpenRandomDialogue(string[] messages, Actor[] actors)
    {
        currentMessages = new Message[messages.Length];
        for (int i = 0; i < messages.Length; i++)
        {
            currentMessages[i] = new Message
            {
                actorId = Random.Range(0, actors.Length),
                message = messages[i]
            };
        }

        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Comienza conversación mensajes aleatorios cargados: " + messages.Length);
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    #endregion

    public void SetActiveNPC(NPCController npc)
    {
        activeNPC = npc;
    }

    public void FinishConversation()
    {
        conversationFinished = true;
    }
}
