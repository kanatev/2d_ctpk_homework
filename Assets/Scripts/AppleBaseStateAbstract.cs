using UnityEngine;

public abstract class AppleBaseStateAbstract
{
    public bool IsShouldDrop { get ; private set; }

    public abstract void EnterState(AppleStateManagerContext apple);
    public abstract void UpdateState(AppleStateManagerContext apple);
    public abstract void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision2D);
}
