using UnityEngine;

public class AppleWholeState : AppleBaseStateAbstract
{
    private float rottenCountdown = 3f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.25f, 0.25f);
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
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
