using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DrunkEffect : MonoBehaviour
{
    // when a rotten apple is eaten this effect starts
    // the effect has duration - 3 sec
    // each eaten rotten apple restart timer

    [SerializeField] private PostProcessVolume postProcessVolume;
    private LensDistortion lensDistortion;
    private bool isIncrementing = true;
    public float drunkTime = 0.0f;
    [SerializeField] private float drunkPower = 0.3f;
    [SerializeField] private float drunkEffectSpeed = 0.15f;


    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out lensDistortion);
        // lensDistortion.enabled.Override(true);
    }

    void Update()
    {
        if (drunkTime > 0)
        {
            drunkTime -= Time.deltaTime;
            RunDrunkEffect();
        }
        else 
        {
            // вернем значения в 0
            RunSoberingEffect();
            // если значения 0, то выключим эффект
        }
        
    }

    void RunDrunkEffect()
    {
        if (lensDistortion.enabled)
        {
            if (isIncrementing && lensDistortion.centerX.value < drunkPower)
            {
                if (lensDistortion.intensity.value > - 60)
                {
                    lensDistortion.intensity.value -= 25f * Time.deltaTime;
                }
                
                // if (lensDistortion.intensityX.value < 0.95f)
                // {
                //     lensDistortion.intensityX.value += 0.5f * Time.deltaTime;
                //     lensDistortion.intensityY.value += 0.5f * Time.deltaTime;
                // }

                lensDistortion.centerX.value += drunkEffectSpeed * Time.deltaTime;

                // if (lensDistortion.centerY.value > -0.8f)
                // {
                //     lensDistortion.centerY.value -= 0.2f * Time.deltaTime;
                // }
                
                
                if (lensDistortion.centerX.value > drunkPower)
                {
                    isIncrementing = false;
                }

            } else if (!isIncrementing && lensDistortion.centerX.value > - drunkPower)
            {
                lensDistortion.centerX.value -= drunkEffectSpeed * Time.deltaTime;
                
                if (lensDistortion.centerX.value < - drunkPower)
                {
                    isIncrementing = true;
                }
            }
        }
    }

    void RunSoberingEffect()
    {
        if (lensDistortion.enabled)
        {
            {
                if (lensDistortion.intensity.value < 0)
                {
                    lensDistortion.intensity.value += 25f * Time.deltaTime;
                }
                else
                {
                    lensDistortion.intensity.value = 0.0f;
                    lensDistortion.centerX.value = - drunkPower;
                    drunkTime = 0.0f;
                    isIncrementing = true;
                    lensDistortion.enabled.Override(false);
                }
            } 

        }
    }
}
