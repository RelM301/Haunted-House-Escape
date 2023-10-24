using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public RandomDialogue randomDialogue;
    public GameObject quizPanel;
    private bool interactionActive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (interactionActive && collision.gameObject.CompareTag("Player"))
        {
            // Set the activeNPC in the dialogue manager before starting the dialogue.
            DialogueManager.Instance.SetActiveNPC(this);
            randomDialogue.StartRandomDialogue();
        }
    }

    public void DeactivateInteraction()
    {
        interactionActive = false;
        GetComponent<Collider>().enabled = false;
    }
}
