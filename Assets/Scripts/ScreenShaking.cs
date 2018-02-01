using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaking : MonoBehaviour {
    public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            RotateLeft();
            Invoke("RotateRight", 0.1f);
            Invoke("RotateLeft", 0.15f);
            Invoke("RotateRight", 0.2f);
            Invoke("RotateLeft", 0.25f);
            Invoke("RotateRight", 0.3f);
            Invoke("RotateLeft", 0.35f);
            Invoke("Normal", 0.4f);
        }
    }
    void RotateLeft()
    {
        camera.transform.Rotate(0f, 0f, 4.5f);
    }

    void RotateRight()
    {
        camera.transform.Rotate(0f, 0f, -4.5f);
    }
    void Normal()
    {
        camera.transform.rotation = Quaternion.identity;
    }
}
