using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour
{

    private Vector3 forceVector = new Vector3(1f, 1f, 1);

    public float forceMagnitude = 50;

    public bool trigger;

    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            trigger = true;
        }

        if (trigger)
        {
            trigger = false;
            body.AddForce(forceMagnitude * forceVector);
        }
    }
}
