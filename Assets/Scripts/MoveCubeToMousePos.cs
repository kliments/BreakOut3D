using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeToMousePos : MonoBehaviour {
    private Vector3 pos;
    Vector3 mousePos;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //map the block over the mouse
        mousePos = Input.mousePosition;
        mousePos.z = 0.3f;
        pos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = pos;
    }
}
