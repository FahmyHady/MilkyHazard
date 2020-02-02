using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public float wanderTime;
    public float wanderTimer;
    public float wanderSpeed;
    public Rigidbody myRigidBody;
    public Vector3 wanderDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        wanderTimer += Time.deltaTime;
        // myRigidbody.velocity = Vector3.zero;
        if (wanderTimer > wanderTime)
        {
            wanderDirection = new Vector3(Random.Range(-1f, 1f), 0, 0);
            wanderTimer = 0;
        }
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, wanderDirection, 2f * Time.deltaTime, 0.0f));

        // myRigidBody.velocity = transform.forward * wanderSpeed*Time.deltaTime;
        transform.Translate(Vector3.forward* wanderSpeed*Time.deltaTime, Space.Self);

    }
}
