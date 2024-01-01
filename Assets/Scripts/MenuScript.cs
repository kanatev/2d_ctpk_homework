using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    private bool isMenuOpened;
    private GameObject menuPanel;
    private GameObject hero;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.FindGameObjectWithTag("Menu");
        menuPanel.SetActive(false);
        hero = GameObject.FindGameObjectWithTag("Player");
        playerInput = hero.GetComponent<PlayerInput>();
    }

    public void OnMenuButtonPush()
    {
        if (!isMenuOpened)
        {
            // open menu
            menuPanel.SetActive(true);

            // play sound of a button
            gameObject.GetComponent<AudioSource>().Play();
            
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
            gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
            isMenuOpened = false;
            menuPanel.SetActive(false);
        }
    }
}
