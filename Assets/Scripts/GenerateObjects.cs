using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {

    public GameObject prefab;
    private Vector3 pos;
    private float posX;
	// Use this for initialization
	void Start () {
        posX = 0.5f;
		for(int i=0; i<10; i++)
        {
            GameObject obj = Instantiate(prefab, gameObject.transform.parent);
            pos = gameObject.transform.position;
            pos.x += posX;
            posX += 0.5f;
            obj.transform.position = pos;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
