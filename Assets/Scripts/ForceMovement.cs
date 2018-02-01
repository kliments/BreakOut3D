using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour {
    private Vector3 oldPos, newPos;
	// Use this for initialization
	void Start () {
        oldPos = new Vector3(0, 0, 0);
        newPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        oldPos = newPos;
        newPos = transform.position;
		if((oldPos.x == newPos.x && oldPos.y == newPos.y) 
            || (oldPos.x == newPos.x && oldPos.z == newPos.z)
            || (oldPos.y == newPos.y && oldPos.z == newPos.z))
        {
            gameObject.GetComponent<AddForce>().trigger = true;
        }
	}
}
