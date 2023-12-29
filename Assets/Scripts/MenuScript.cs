using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private bool isMenuOpened;
    GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.FindGameObjectWithTag("Menu");
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuButtonPush()
    {
        if (!isMenuOpened)
        {
            // open menu
            menuPanel.SetActive(true);
            // play sound of a button
            gameObject.GetComponent<AudioSource>().Play();
            isMenuOpened = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void OnResumeButtonPush()
    {
        if (isMenuOpened)
        {
            menuPanel.SetActive(false);
            gameObject.GetComponent<AudioSource>().Play();
            isMenuOpened = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
