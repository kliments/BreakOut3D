using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    public GameObject points;
    public GameObject lives;
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
            points.GetComponent<UpdatePointsAndLives>().points += 10;
            points.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GameOverWall" && temp==null)
        {
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            lives.GetComponent<UpdatePointsAndLives>().lives--;
            lives.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(gameObject);
        }
    }
}
