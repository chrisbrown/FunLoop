using UnityEngine;
using System.Collections;

public class SetCubeColor : MonoBehaviour {

    Color newCol = new Color(1f, 1f, 1f);
    void Awake ()
    {
        renderer.material.color = newCol;
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
