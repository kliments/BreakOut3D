using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {
    
    public List<GameObject> prefab;
    private Vector3 pos;
    private float posX;
    private int j;
	// Use this for initialization
	void Start () {
        posX = 0.5f;
		for(int i=0; i<10; i++)
        {
            j = (int)Random.Range(0, 3.9f);
            GameObject obj = Instantiate(prefab[j], gameObject.transform.parent);
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
