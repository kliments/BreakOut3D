using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    public GameObject points;
    public GameObject lives;
    public GameObject ball;
    private GameObject temp;
    private Vector3 position, scale;
    
	// Use this for initialization
	void Start () {
        temp = null;
        position = transform.position;
        scale = new Vector3(0.1f, 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "destroy")
        {
            if(collision.gameObject.name.Contains("Cylinder"))
            {
                PowerUp(collision.gameObject);
            }
            points.GetComponent<UpdatePointsAndLives>().points += 10;
            points.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GameOverWall" && temp == null && gameObject.name == "Ball")
        {
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            temp.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
            lives.GetComponent<UpdatePointsAndLives>().lives--;
            lives.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(gameObject);
        }
        else if(collider.gameObject.name.Contains("Cylinder"))
        {
            Destroy(collider.gameObject);
        }
    }

    private void PowerUp(GameObject cylinder)
    {
        if(cylinder.GetComponent<PowerUpScript>().multiBall)
        {
            GameObject secondBall = Instantiate(ball, gameObject.transform.position,Quaternion.identity);
            secondBall.name = "SecondBall";
            secondBall.GetComponent<AddForce>().trigger = true;
            Destroy(secondBall, 5f);
        }
        else if(cylinder.GetComponent<PowerUpScript>().biggerBall)
        {
            scale += new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.localScale = scale;
        }
    }
}
