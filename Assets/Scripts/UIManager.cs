using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        print("Exit");
#endif
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            // Unlock the cursor and make it visible in the main menu
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
