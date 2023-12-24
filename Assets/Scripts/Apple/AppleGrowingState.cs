using UnityEngine;

public class AppleGrowingState : AppleBaseStateAbstract
{
    Vector2 startingAppleSize = new Vector2(0.3f, 0.3f);

    public override void EnterState(AppleStateManagerContext apple)
    {
        Debug.Log("growing state enter");
        apple.transform.localScale = startingAppleSize;
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (apple.transform.localScale.x < 1f)
        {
            apple.transform.localScale = new Vector2(apple.transform.localScale.x + 0.5f * Time.deltaTime, apple.transform.localScale.y + 0.5f * Time.deltaTime);
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
