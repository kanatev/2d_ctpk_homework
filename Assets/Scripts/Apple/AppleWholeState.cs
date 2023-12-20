using UnityEngine;

public class AppleWholeState : AppleBaseStateAbstract
{
    float rottenCountdown = 3f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        apple.GetComponent<Rigidbody2D>().gravityScale = 1;
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
            Debug.Log("rotten");
        }
    }

    public override void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("add health");
            apple.SwitchState(apple.ChewedState);
            // other.GetComponent<PlayerController>.addHealth();
        }
    }
}
