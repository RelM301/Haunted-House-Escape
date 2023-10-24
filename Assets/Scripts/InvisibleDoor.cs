using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InvisibleDoor : MonoBehaviour
{
    private bool canPass = false;
    public GameManager gameManager;

    public void MakePassable()
    {
        canPass = true;
        // Disable the collider to make it passable
        GetComponent<Collider>().enabled = false;
    }

    public void MakeImpassable()
    {
        canPass = false;
        // Enable the collider to make it impassable
        GetComponent<Collider>().enabled = true;
    }

    public bool IsPassable()
    {
        return canPass;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("LastDoor"))
            {
                Debug.Log("Player collided with the LastDoor.");
                gameManager.MainMenu();
            }
        }
    }
}
