using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    private bool isMenuOpened;
    private GameObject menuPanel;
    private GameObject playerInputObject;
    private PlayerInput playerInput;
    private GameObject menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.FindGameObjectWithTag("Menu");
        menuPanel.SetActive(false);
        playerInputObject = GameObject.FindGameObjectWithTag("PlayerInput");
        playerInput = playerInputObject.GetComponent<PlayerInput>();
        menuButton = GameObject.FindGameObjectWithTag("MenuButton");
    }
    
    public void OnMenuButtonPush()
    {
        if (!isMenuOpened)
        {
            // open menu
            menuPanel.SetActive(true);

            // play sound of a button
            menuButton.GetComponent<AudioSource>().Play();
            
            
            // pause the game
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            playerInput.SwitchCurrentActionMap("UI");
            isMenuOpened = true;
        }
    }
    public void OnResumeButtonPush()
    {
        if (isMenuOpened)
        {
            menuButton.GetComponent<AudioSource>().Play();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
            isMenuOpened = false;
            menuPanel.SetActive(false);
        }
    }
}
