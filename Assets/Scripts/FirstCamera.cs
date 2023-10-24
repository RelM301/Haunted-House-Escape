using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    private float maxCameraRotation = 16f;

    // Reference to the game over panel
    public GameObject pauseGamePanel;
    public GameObject questionOnePanel;
    public GameObject questionTwoPanel;
    public GameObject questionThreePanel;
    public GameObject questionFourPanel;
    public GameObject questionFivePanel;
    public GameObject questionSixPanel;
    public GameObject wrongAnswerPanel;
    public GameObject rightAnswerPanel;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game over panel is active
        bool isPauseGamePanelActive = pauseGamePanel.activeInHierarchy;
        bool isQuestionOnePanelActive = questionOnePanel.activeInHierarchy;
        bool isQuestionTwoPanelActive = questionTwoPanel.activeInHierarchy;
        bool isQuestionThreePanelActive = questionThreePanel.activeInHierarchy;
        bool isQuestionFourPanelActive = questionFourPanel.activeInHierarchy;
        bool isQuestionFivePanelActive = questionFivePanel.activeInHierarchy;
        bool isQuestionSixPanelActive = questionSixPanel.activeInHierarchy;
        bool isWrongAnswerPanelActive = wrongAnswerPanel.activeInHierarchy;
        bool isRightAnserPanelActive = rightAnswerPanel.activeInHierarchy;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (isPauseGamePanelActive || isQuestionOnePanelActive || isWrongAnswerPanelActive || isRightAnserPanelActive || isQuestionTwoPanelActive || isQuestionThreePanelActive || isQuestionFourPanelActive || isQuestionFivePanelActive || isQuestionSixPanelActive || currentSceneIndex == 0)
        {
            // Unlock the cursor and make it visible
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Lock the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Collect mouse input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera around its local X axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -maxCameraRotation, maxCameraRotation);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        transform.localEulerAngles = new Vector3(cameraVerticalRotation, 0f, 0f);
        player.Rotate(Vector3.up * inputX);
    }
}
