using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
    public float radius = 5.0F;
    public float power = 10.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            Vector3 explosionPos = new Vector3(0, 0, 0);
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit && hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }
	}
}
