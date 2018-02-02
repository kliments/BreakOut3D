using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour {
    private Vector3 oldPos, newPos, shiftPosition;
    public bool isMoving;
    public GameObject planeParent;
	// Use this for initialization
	void Start () {
        isMoving = false;
        oldPos = new Vector3(0, 0, 0);
        newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        shiftPosition = planeParent.transform.position;
        shiftPosition.z += 0.173f;
        oldPos = newPos;
        newPos = transform.position;
		if((oldPos.x == newPos.x && oldPos.y == newPos.y && isMoving) 
            || (oldPos.x == newPos.x && oldPos.z == newPos.z && isMoving)
            || (oldPos.y == newPos.y && oldPos.z == newPos.z && isMoving))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(50f * new Vector3(1,1,1));
        }

        if(!isMoving && gameObject.name=="Ball")
        {
            transform.position = shiftPosition;
        }

	}
}
