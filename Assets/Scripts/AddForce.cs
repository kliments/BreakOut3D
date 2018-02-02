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
        trigger = false;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.parent = null;
            trigger = true;
        }

        if (trigger)
        {
            trigger = false;
            body.AddForce(forceMagnitude * forceVector);
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            GetComponent<ForceMovement>().isMoving = true;
        }

        if(gameObject.name == "SecondBall" && !GetComponent<ForceMovement>().isMoving)
        {
            trigger = true;
        }
    }
}
