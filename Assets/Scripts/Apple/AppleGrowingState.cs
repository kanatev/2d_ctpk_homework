using UnityEngine;

public class AppleGrowingState : AppleBaseStateAbstract
{
    Vector2 startingAppleSize = new Vector2(0.1f, 0.1f);

    public override void EnterState(AppleStateManagerContext apple)
    {
        Debug.Log("growing state enter");
        apple.transform.localScale = startingAppleSize;
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (apple.transform.localScale.x < 0.3f)
        {
            apple.transform.localScale = new Vector2(apple.transform.localScale.x + 0.1f * Time.deltaTime, apple.transform.localScale.y + 0.1f * Time.deltaTime);
        } 
        else
        {
            apple.SwitchState(apple.WholeState);
        }
    }

    public override void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {

    }
}
