using UnityEngine;

public class AppleRottenState : AppleBaseStateAbstract
{
    private float rottenDropCountdown = 2f;
    private float exploidCountdown = 5f;
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
                isRottenDropped = true;
            }
        }
        if (exploidCountdown >= 0)
        {
            exploidCountdown -= Time.deltaTime;
        }
        else
        {
            // let's exploid the rotten apple
            if (apple.gameObject != null)
            {
                Object.Destroy(apple.gameObject);
            }
        }
    }

    public override void AppleOnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            apple.SwitchState(apple.ChewedState);
        }
    }
}
