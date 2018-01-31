using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerBall : MonoBehaviour {
    public bool bigBallHit;
    public GameObject ball;
	// Use this for initialization
	void Start () {
        bigBallHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(bigBallHit)
        {
            bigBallHit = false;
            ball.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
	}
}
