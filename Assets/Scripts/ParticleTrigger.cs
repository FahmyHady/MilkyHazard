using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ParticleTrigger : MonoBehaviour
{
    List<ParticleCollisionEvent> enter2 = new List<ParticleCollisionEvent>();
    static ParticleSystem mainParticle;
    int count;
    GameObject savedObject;
    FireComponent savedFireComponenet;
    private void Awake()
    {
        mainParticle = GetComponent<ParticleSystem>();
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
                Debug.Log(savedObject.name);
                savedFireComponenet = savedObject.GetComponent<FireComponent>();
                savedFireComponenet?.hit();
            }
            else
            {
                print(savedFireComponenet);

                savedFireComponenet?.hit();

            }
        }

    }

}



