using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AppleRottenState : AppleBaseStateAbstract
{
    private float rottenDropCountdown = 2f;
    private bool isRottenDropped = false;


    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.0f, 0.0f);
    }

    

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (rottenDropCountdown >= 0)
        {
            rottenDropCountdown -= Time.deltaTime;
        }
        else
        {
            if(!isRottenDropped)
            {
                apple.GetComponent<Rigidbody2D>().gravityScale = 1;
                apple.GetComponent<Collider2D>().enabled = true;
                apple.GetComponentInChildren<Collider2D>(false).enabled = true;   
                isRottenDropped = true;
                // let's say to the tree that this apple dropped (position)

            }
        }
        
    }

    public override void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("minus health");
            apple.SwitchState(apple.ChewedState);
            // other.GetComponent<PlayerController>.detractHealth();
        }
    }
}
