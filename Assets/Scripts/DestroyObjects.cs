using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    public GameObject points;
    public GameObject lives;
    public GameObject ball;
    public GameObject listParent;
    private GameObject temp;
    private Vector3 position, scale;

    public AudioSource source;
    public AudioClip clipWall, clipObject, clipPowerUp, clipPowerDown, clipLifeLost;
    
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

            else if (collision.gameObject.name.Contains("Capsule"))
            {
                PowerDown(collision.gameObject);
            }
            else
            {
                source.clip = clipObject;
                source.Play();
            }
            points.GetComponent<UpdatePointsAndLives>().points += 10;
            points.GetComponent<UpdatePointsAndLives>().update = true;
            DestroyGameObject(collision.gameObject);

        }

        else if(collision.gameObject.tag == "Wall")
        {
            source.clip = clipWall;
            source.Play();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GameOverWall" && temp == null && gameObject.name == "Ball")
        {
            source.clip = clipLifeLost;
            source.Play();
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            temp.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
            lives.GetComponent<UpdatePointsAndLives>().lives--;
            lives.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(gameObject);
        }
        else if(collider.gameObject.name.Contains("Cylinder"))
        {
            source.clip = clipPowerUp;
            source.Play();
            DestroyGameObject(collider.gameObject);
        }
    }

    private void PowerUp(GameObject cylinder)
    {
        source.clip = clipPowerUp;
        source.Play();
        if (cylinder.GetComponent<PowerUpScript>().multiBall)
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

    private void PowerDown(GameObject capsule)
    {
        source.clip = clipPowerDown;
        source.Play();
        if (capsule.GetComponent<PowerDownScript>().fasterBall)
        {
            gameObject.GetComponent<MaintainEnergy>().kinematicEnergyLevel = 20;
            Invoke("SpeedBackToNormal", 5f);
        }
        else if (capsule.GetComponent<PowerDownScript>().smallerBall)
        {
            if(scale.x>0)
            {
                scale -= new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.localScale = scale;
            }
        }
        else if(capsule.GetComponent<PowerDownScript>().destroyBall && gameObject.name == "Ball")
        {
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            temp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            lives.GetComponent<UpdatePointsAndLives>().lives--;
            lives.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(gameObject);
        }
    }

    private void SpeedBackToNormal()
    {
        gameObject.GetComponent<MaintainEnergy>().kinematicEnergyLevel = 5;
    }

    private void DestroyGameObject(GameObject obj)
    {
        
        for(int i=0; i<listParent.GetComponent<EndOfGame>().list.Count; i++)
        {
            if(obj.GetInstanceID() == listParent.GetComponent<EndOfGame>().list[i].GetInstanceID())
            {
                listParent.GetComponent<EndOfGame>().list.RemoveAt(i);
            }
        }
        Destroy(obj);
    }
}
