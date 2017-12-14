using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour {

    public Vector3 forceVector = new Vector3(0, 0, 1);

    public float forceMagnitude = 50;

    public bool trigger;

    private Rigidbody body;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (trigger)
        {
            trigger = false;
            body.AddForce(forceMagnitude * forceVector);            
        }
	}
}
