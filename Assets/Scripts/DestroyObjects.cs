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
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
            points.GetComponent<UpdatePointsAndLives>().points += 10;
            points.GetComponent<UpdatePointsAndLives>().update = true;
            DestroyGameObject(collision.gameObject);

        }

        else if(collision.gameObject.tag == "Wall")
        {
            source.clip = clipWall;
            if (!source.isPlaying)
            {
                source.Play();
            }
            gameObject.GetComponent<ParticleSystem>().Play();
        }

        else if(collision.gameObject.name == "SquarePaddle")
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GameOverWall" && temp == null && gameObject.name == "Ball")
        {
            source.clip = clipLifeLost;
            if (!source.isPlaying)
            {
                source.Play();
            }
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            temp.GetComponent<AddForce>().trigger = false;
            temp.GetComponent<TrailRenderer>().enabled = false;
            temp.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
            lives.GetComponent<UpdatePointsAndLives>().lives--;
            lives.GetComponent<UpdatePointsAndLives>().update = true;
            Destroy(gameObject);
        }
        else if(collider.gameObject.name.Contains("Cylinder"))
        {
            source.clip = clipPowerUp;
            if (!source.isPlaying)
            {
                source.Play();
            }
            DestroyGameObject(collider.gameObject);
        }
    }

    private void PowerUp(GameObject cylinder)
    {
        source.clip = clipPowerUp;
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (cylinder.GetComponent<PowerUpScript>().multiBall)
        {
            GameObject secondBall = Instantiate(ball, gameObject.transform.position,Quaternion.identity);
            secondBall.name = "SecondBall";
            secondBall.tag = "Ball";
            secondBall.GetComponent<AddForce>().trigger = true;
            Destroy(secondBall, 5f);
        }
        else if(cylinder.GetComponent<PowerUpScript>().biggerBall)
        {
            scale += new Vector3(0.01f, 0.01f, 0.01f);
            gameObject.transform.localScale = scale;
        }
    }

    private void PowerDown(GameObject capsule)
    {
        source.clip = clipPowerDown;
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (capsule.GetComponent<PowerDownScript>().fasterBall)
        {
           gameObject.GetComponent<MaintainEnergy>().kinematicEnergyLevel = 20;
            Invoke("SpeedBackToNormal", 5f);
        }
        else if (capsule.GetComponent<PowerDownScript>().smallerBall)
        {
            if(scale.x>0.01f)
            {
                scale -= new Vector3(0.01f, 0.01f, 0.01f);
                gameObject.transform.localScale = scale;
            }
        }
        else if(capsule.GetComponent<PowerDownScript>().destroyBall && gameObject.name == "Ball")
        {
            temp = Instantiate(ball, position, Quaternion.identity);
            temp.name = "Ball";
            temp.GetComponent<AddForce>().trigger = false;
            temp.GetComponent<TrailRenderer>().enabled = false;
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

        StartCoroutine(obj.GetComponent<TriangleExplosion>().SplitMesh(true));
        obj.SetActive(false);
        Destroy(obj,2f);
    }
}
