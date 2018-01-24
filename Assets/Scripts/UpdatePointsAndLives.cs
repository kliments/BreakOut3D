using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePointsAndLives : MonoBehaviour {

    public int points, lives;
    public bool update;
	// Use this for initialization
	void Start () {
        update = false;
        points = 0;
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.name == "Points" && update)
        {
            update = false;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Points: " + points.ToString();
        }
        else if (gameObject.name == "Lives" && update)
        {
            update = false;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + lives.ToString();
        }
    }
}
