using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomTexture : MonoBehaviour {
    public List<Material> materials;
	// Use this for initialization
	void Start () {
        int i = Random.Range(0, 3);
        gameObject.GetComponent<MeshRenderer>().material = materials[i];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
