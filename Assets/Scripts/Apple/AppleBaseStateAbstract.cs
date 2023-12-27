using UnityEngine;

public abstract class AppleBaseStateAbstract
{
    public abstract void EnterState(AppleStateManagerContext apple);
    public abstract void UpdateState(AppleStateManagerContext apple);
    public abstract void AppleOnCollisionEnter(AppleStateManagerContext apple, Collision2D collision2D);
}
