using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.SendMessage("Pickup", gameObject, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Pickup " + gameObject.tag);
        }
    }
}
