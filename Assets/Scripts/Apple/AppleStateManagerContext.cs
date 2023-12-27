using UnityEngine;

public class AppleStateManagerContext : MonoBehaviour
{

    AppleBaseStateAbstract currentState;
    public AppleGrowingState GrowingState = new AppleGrowingState();
    public AppleRottenState RottenState = new AppleRottenState();
    public AppleWholeState WholeState = new AppleWholeState();
    public AppleChewedState ChewedState = new AppleChewedState();


    // Start is called before the first frame update
    void Start()
    {
        currentState = GrowingState;
        currentState.EnterState(this);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        currentState.AppleOnCollisionEnter(this, other);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AppleBaseStateAbstract state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
