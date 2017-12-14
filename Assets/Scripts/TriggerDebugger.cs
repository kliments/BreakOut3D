using UnityEngine;
using System.Collections;

public class TriggerDebugger : MonoBehaviour {

	public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + ".OnTriggerEnter(): other = " + other.gameObject.name);
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(gameObject.name + ".OnTriggerStay(): other = " + other.gameObject.name);
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log(gameObject.name + ".OnTriggerExit(): other = " + other.gameObject.name);
    }


}
