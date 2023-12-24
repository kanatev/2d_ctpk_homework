using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AppleChewedState : AppleBaseStateAbstract
{
    private GameObject scoreDigit;
    private Vector3 scorePos;
    private const string AppleTreeTag = "AppleTree";
    private const string ScoreDigitTag = "ScoreDigit";
    private float appleFlightSpeed = 5f;


    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<Rigidbody2D>().gravityScale = 0;
        apple.GetComponent<Rigidbody2D>().freezeRotation = true;
        apple.GetComponent<Collider2D>().enabled = false;

        scoreDigit = GameObject.FindWithTag(ScoreDigitTag);
        scorePos = Vector3.zero;
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        scorePos = Camera.main.ScreenToWorldPoint(scoreDigit.transform.position);
        
        if (apple.transform.position.x != scorePos.x && apple.transform.position.y != scorePos.y)
        {
            apple.transform.position = Vector2.MoveTowards(apple.transform.position, scorePos, appleFlightSpeed * Time.deltaTime);
        }
        else
        {
            Object.Destroy(apple.gameObject);
            // apple.transform.position
            // apple.SwitchState(apple.GrowingState);            
        }
    }

    public override void OnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        
    }
}
