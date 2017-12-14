using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Vector3 direction;
    private const float speed = 0.1f;
    // Use this for initialization
    void Start () {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * speed * Time.deltaTime;
    }
}
