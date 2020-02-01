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
            
        }
        else
        {
            SmokeEffect.Stop();
        }

    }

    public void hit()
    {
        wet = true;
        fireLifeTimer = 1;
        print("sqiurted");
    }
}
