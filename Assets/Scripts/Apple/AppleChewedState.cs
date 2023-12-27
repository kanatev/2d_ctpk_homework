using UnityEngine;
using DG.Tweening;

public class AppleChewedState: AppleBaseStateAbstract
{
    // private GameObject scoreDigit;
    private Vector3 scorePos;
    private const string ScoreTag = "Score";
    private float appleDestroyCountdown = 0.5f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<Rigidbody2D>().gravityScale = 0;
        apple.GetComponent<Rigidbody2D>().freezeRotation = true;
        apple.GetComponent<Collider2D>().enabled = false;
        GameObject scoreDigit = GameObject.FindWithTag(ScoreTag);
        scorePos = Vector3.zero;
        scorePos = Camera.main.ScreenToWorldPoint(scoreDigit.transform.position);
        scorePos.z = 0f;
        apple.transform.DOMove(scorePos, appleDestroyCountdown);
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (appleDestroyCountdown >= 0f)
        {
            appleDestroyCountdown -= Time.deltaTime;
        }
        else
        {
            if (apple.gameObject != null)
            {
                Object.Destroy(apple.gameObject);
            }
        }
    }

    public override void AppleOnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        
    }
}
