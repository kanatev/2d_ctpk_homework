using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    private bool isMenuOpened;
    GameObject menuPanel;
    [SerializeField] PlayerInput playerInputActions;
    private PlayerInput playerInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.FindGameObjectWithTag("Menu");
        menuPanel.SetActive(false);

        // Create an instance of the default actions.
        var actions = new DefaultInputActions();
        // actions.Player.Look.performed += OnLook;
        // actions.Player.Move.performed += OnMove;
        actions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void OnMenuButtonPush(InputAction.CallbackContext context)

    // private void OnEnable() {
        
    // }

    public void OnMenuButtonPush()
    {
        if (!isMenuOpened)
        {
            // open menu
            menuPanel.SetActive(true);
            // play sound of a button
            gameObject.GetComponent<AudioSource>().Play();
            
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;

            playerInput.SwitchCurrentActionMap("UI");

            isMenuOpened = true;

            // InputActionMap inputActionMap = FindA

            // InputActionMap.
            // action
            // gameplayActions.Enable();

            // playerInputActions.
            // PlayerInputManager.input
            // playerInputActions.t
            // playerInputActions.playerIndex
        }
    }
    public void OnResumeButtonPush()
    {
        if (isMenuOpened)
        {
            menuPanel.SetActive(false);
            gameObject.GetComponent<AudioSource>().Play();
            
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;

            playerInput.SwitchCurrentActionMap("Player");

            isMenuOpened = false;
        }
    }
}
