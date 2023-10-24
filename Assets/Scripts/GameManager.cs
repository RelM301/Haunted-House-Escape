using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = true;

    // Reference to other components or managers
    public PlayerMovement playerMovement; // Replace with your actual PlayerMovement

    void Update()
    {
        
    }

    void GameOver()
    {
        // Set the game state to inactive
        isGameActive = false;

        // Stop or pause various game components
        playerMovement.enabled = false;

        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        // Set the game state to inactive
        isGameActive = false;

        // Stop or pause various game components
        playerMovement.enabled = false;

        Time.timeScale = 0;
    }

    public void ReturnToGame()
    {
        isGameActive = true;

        // Stop or pause various game components
        playerMovement.enabled = true; 
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
