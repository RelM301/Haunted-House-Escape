using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform mainCamera;
    public GameManager gameManager;
    public GameObject pauseGamePanel;
    public float speed = 3f;

    public AudioSource footstepAudioSource; // Reference to the AudioSource for footsteps
    public AudioClip footstepSound; // The footstep sound

    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;

        // Initialize the footstep audio source and clip
        footstepAudioSource = GetComponent<AudioSource>();
        footstepAudioSource.clip = footstepSound;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.forward;
        Vector3 right = mainCamera.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * movementVertical + right * movementHorizontal;
        movement = movement.normalized * speed * Time.deltaTime;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager != null && pauseGamePanel != null)
            {
                gameManager.PauseGame();
                pauseGamePanel.SetActive(true);
            }
        }

        if (DialogueManager.isActive == true)
        {
            rb.velocity = Vector3.zero;
            // Stop footstep sound when not moving
            footstepAudioSource.Stop();
            isMoving = false;
        }
        else
        {
            if (movement != Vector3.zero)
            {
                // Play footstep sound when moving
                if (!isMoving)
                {
                    footstepAudioSource.Play();
                    isMoving = true;
                }
            }
            else
            {
                // Stop footstep sound when not moving
                footstepAudioSource.Stop();
                isMoving = false;
            }
        }
    }
}
