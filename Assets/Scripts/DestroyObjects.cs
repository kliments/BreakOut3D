using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    public GameObject ui;
    public GameObject ball;
    private GameObject temp;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        temp = null;
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "destroy")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GameOverWall" && temp==null)
        {
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            Destroy(gameObject);
        }
    }
}
