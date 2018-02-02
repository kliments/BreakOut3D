using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour {
    public List<GameObject> list;
    private int random;
	// Use this for initialization
	void Start () {
        Invoke("Delay", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            random = Random.Range(0, transform.childCount);
            if(list[random]!=null)
            {
                Destroy(list[random]);
                list.RemoveAt(random);
            }
        }

        if(transform.childCount == 0)
        {
            Application.Quit();
            Debug.Log("End Of Game!!!");
        }
	}

    void Delay()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            list.Add(transform.GetChild(i).gameObject);
        }
    }
}
