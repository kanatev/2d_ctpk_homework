using UnityEngine;

public class AppleChewedState : AppleBaseStateAbstract
{

    float destroyCountdown = 3f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        Animator animator = apple.GetComponent<Animator>();
        animator.Play("Base Layer.chewed", 0, 0);
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (destroyCountdown > 0)
        {
            destroyCountdown -= Time.deltaTime;
        }
        else
        {
            Object.Destroy(apple.gameObject);
        }
    }

    public override void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {

    }
}
