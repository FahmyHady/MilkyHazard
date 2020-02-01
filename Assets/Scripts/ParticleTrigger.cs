using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ParticleTrigger : MonoBehaviour
{
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleCollisionEvent> enter2 = new List<ParticleCollisionEvent>();
    static ParticleSystem mainParticle;
    int count;
    static int collidersCounter;
    GameObject savedObject;
   // FireComponent savedFireComponenet;
    private void Awake()
    {
        mainParticle = GetComponent<ParticleSystem>();
    }
    public static void AddToTriggers(Collider colliderToAdd)
    {


        mainParticle.trigger.SetCollider(collidersCounter, colliderToAdd);
        collidersCounter++;
    }
    private void OnParticleCollision(GameObject other)
    {
        count = ParticlePhysicsExtensions.GetCollisionEvents(mainParticle, other, enter2);
        if (count > 0)
        {

            GameObject tempObject = other;
            if (tempObject != savedObject)
            {
                savedObject = tempObject;
             //   savedFireComponenet = savedObject.GetComponent<FireComponent>();
                savedFireComponenet?.hit();
            }
            else
            {
                savedFireComponenet?.hit();

            }
        }

    }

}



