using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    public enum FireStage { Stage1, Stage2, Stage3}

    public float fireHealth;
    public float fireDieFactor;
    public float fireLifeTimer;

    public FireStage currentStage;
    public ParticleSystem fireEffect;
    public ParticleSystem SmokeEffect;


    public bool wet;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (wet)
        {
            fireHealth -= Time.deltaTime * fireDieFactor;
            fireLifeTimer -= Time.deltaTime;
            if (fireLifeTimer < 0) wet = false;
            if (!SmokeEffect.isEmitting)
            SmokeEffect.Play();
        }
        else
        {
            SmokeEffect.Stop();
        }

        if (fireHealth > 70)
        {
            
        }

        else if (fireHealth > 20)
        {
            ParticleSystem.EmissionModule emissionModule =fireEffect.emission;
            emissionModule.rateOverTime = 20;
        }
        else if (fireHealth > 1)
        {
            ParticleSystem.EmissionModule emissionModule = fireEffect.emission;
            emissionModule.rateOverTime = 5;

        }
        else if (fireHealth < 0)
        {
            fireEffect.Stop();
            
        }

    }

    public void hit()
    {
        wet = true;
        fireLifeTimer = 1;
        print("sqiurted");
    }
}
