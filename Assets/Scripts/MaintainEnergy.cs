using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MaintainEnergy : MonoBehaviour {

    public float kinematicEnergyLevel;

    public float velocityThreshold =2f;

    public string runtimeSection = "----- RUNTIME -----";

    public float objectEnergy;

    public float deltaEnergy;

    private Rigidbody body;

    // Use this for initialization
    void Start () {
        this.body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        objectEnergy = body.velocity.magnitude * body.velocity.magnitude * body.mass / 2;
        
        if (body.velocity.magnitude > velocityThreshold)
        {
            body.velocity = body.velocity.normalized * Mathf.Sqrt(2 * kinematicEnergyLevel / body.mass);
        }

	}
}
