using UnityEngine;

public class AppleWholeState : AppleBaseStateAbstract
{
    private float rottenCountdown = 3f;
    // private readonly bool shouldDrop = false;
    // public bool ShouldDrop => shouldDrop;
    // private bool shouldDie = false;
    // public bool ShouldDie { get => shouldDie; set => shouldDie = value; }
    // short example
    // public bool IsJumpPressed { get ; private set; }


    public override void EnterState(AppleStateManagerContext apple)
    {
        // apple.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        apple.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.25f, 0.25f);

    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (rottenCountdown >= 0)
        {
            rottenCountdown -= Time.deltaTime;

            // if the tree is hit then apple drop
            if (IsShouldDrop)
            {
                apple.GetComponent<Rigidbody2D>().gravityScale = 1;
                apple.GetComponent<Collider2D>().enabled = true;
            }
        }
        else
        {
            apple.SwitchState(apple.RottenState);
            // rottenCountdown = 1f; // for now just for testing
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
        if (other.CompareTag("Damage"))
        {
            Object.Destroy(apple.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
    }
}
