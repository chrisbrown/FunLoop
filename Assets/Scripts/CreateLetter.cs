using UnityEngine;
using System.Collections;

public class CreateLetter : MonoBehaviour {

    void Awake ()
    {
        transform.localScale = new Vector3(-100, 100, 100);
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<BoxCollider>();
        //gameObject.collider.enabled = false;
        gameObject.rigidbody.useGravity = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
