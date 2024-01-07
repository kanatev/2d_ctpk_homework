using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AppleRottenState : AppleBaseStateAbstract
{
    private LensDistortion lensDistortion;
    private float exploidCountdown = 5f;
    private DrunkEffect drunkEffect;
    private GameObject gameObjectDrunkEffect;

    public override void EnterState(AppleStateManagerContext apple)
    {
        apple.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.0f, 0.0f);
        apple.GetComponent<ParticleSystem>().Play();
        gameObjectDrunkEffect = GameObject.FindGameObjectWithTag("DrunkEffect");
        gameObjectDrunkEffect.GetComponent<PostProcessVolume>().profile.TryGetSettings(out lensDistortion);
        drunkEffect = gameObjectDrunkEffect.GetComponent<DrunkEffect>();
    }

    public override void UpdateState(AppleStateManagerContext apple)
    {
        if (exploidCountdown >= 0)
        {
            exploidCountdown -= Time.deltaTime;
        }
        else
        {
            // let's exploid the rotten apple
            if (apple.gameObject != null)
            {
                Object.Destroy(apple.gameObject);
            }
        }
    }

    public override void AppleOnCollisionEnter(AppleStateManagerContext apple, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            // run drunk effect
            drunkEffect.drunkTime += 5;
            lensDistortion.enabled.Override(true);
            apple.SwitchState(apple.ChewedState);

        }
    }
}
