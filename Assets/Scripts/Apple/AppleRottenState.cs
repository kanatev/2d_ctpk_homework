using UnityEngine;

public class AppleRottenState : AppleBaseStateAbstract
{
    private float exploidCountdown = 5f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.0f, 0.0f);
        apple.GetComponent<ParticleSystem>().Play();
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
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
