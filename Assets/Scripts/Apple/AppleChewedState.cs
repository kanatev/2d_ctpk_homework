using UnityEngine;
using DG.Tweening;
using TMPro;

public class AppleChewedState: AppleBaseStateAbstract
{
    private Vector3 scorePos;
    GameObject scoreLabel;
    private const string ScoreTag = "Score";
    private float appleDestroyCountdown = 0.5f;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<Rigidbody2D>().gravityScale = 0;
        apple.GetComponent<Rigidbody2D>().freezeRotation = true;
        apple.GetComponent<Collider2D>().enabled = false;
        scoreLabel = GameObject.FindWithTag(ScoreTag);
        scorePos = Vector3.zero;
        scorePos = Camera.main.ScreenToWorldPoint(scoreLabel.transform.position);
        scorePos.z = 0f;
        apple.transform.DOMove(scorePos, appleDestroyCountdown);

        // add in score (right in label for now)
        int counter = int.Parse(scoreLabel.GetComponentsInChildren<TextMeshProUGUI>()[1].text);
        counter += 1;
        scoreLabel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = counter.ToString();

        // play sound
        apple.GetComponent<AudioSource>().Play();
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
