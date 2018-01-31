using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
    private int randomNr;
    public bool multiBall, biggerBall, strikeThrough = false;
    //public PhysicMaterial mat;
	// Use this for initialization
	void Start () {
        randomNr = Random.Range(1, 4);
        switch(randomNr)
        {
            case 1:
                multiBall = true;
                break;
            case 2:
                biggerBall = true;
                break;
            case 3:
                strikeThrough = true;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                break;
            default:
                biggerBall = true;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
