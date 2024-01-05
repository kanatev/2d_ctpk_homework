using UnityEngine;

public class AppleWholeState : AppleBaseStateAbstract
{
    private float rottenCountdown = 5f;
    private float dropCountdown = 2f;
    private bool isAppleDropped = false;


    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.25f, 0.25f);
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (dropCountdown >= 0)
        {
            dropCountdown -= Time.deltaTime;
        }
        else
        {
            if(!isAppleDropped)
            {
                apple.GetComponent<Rigidbody2D>().gravityScale = 1;
                apple.GetComponent<Collider2D>().enabled = true;
                isAppleDropped = true;
            }
        }

        if (rottenCountdown >= 0)
        {
            rottenCountdown -= Time.deltaTime;
        }
        else
        {
            apple.SwitchState(apple.RottenState);
        }
    }

    public override void AppleOnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            apple.SwitchState(apple.ChewedState);
        }
        if (other.CompareTag("Damage"))
        {
            Object.Destroy(apple.gameObject);
        }
    }
}
