using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TriggerBounce : MonoBehaviour {

    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {

        Vector3 avgNormal = new Vector3(0,0,0);

        foreach (ContactPoint contact in collision.contacts)
        {
            avgNormal += contact.normal;            
        }
        avgNormal /= collision.contacts.Length;

        avgNormal = avgNormal.normalized * body.velocity.magnitude;

        body.AddForce(avgNormal, ForceMode.VelocityChange);
        

    }
}
