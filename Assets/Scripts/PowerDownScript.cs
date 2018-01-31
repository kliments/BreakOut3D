using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownScript : MonoBehaviour
{
    private int randomNr;
    public bool fasterBall, smallerBall, destroyBall = false;

    // Use this for initialization
    void Start ()
    {
        randomNr = Random.Range(1, 4);
        switch (randomNr)
        {
            case 1:
                fasterBall = true;
                break;
            case 2:
                smallerBall = true;
                break;
            case 3:
                destroyBall = true;
                break;
            default:
                destroyBall = true;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
