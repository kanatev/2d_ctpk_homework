using UnityEngine;

public class AppleRottenState : AppleBaseStateAbstract
{
    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {

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
