using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {
    public string text = "Hello World";
    public int score = 0;
    public int height = 390;
    public int width = 450;

    void Awake()
    {
        //height = Screen.currentResolution.height;
        //width = Screen.currentResolution.width / 2;
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
       
	}
    void OnGUI() {
        text = GUI.TextField(new Rect(width, height, 200, 20), text, 50);
        GUI.Box(new Rect(0, 0, 20, 20), score.ToString());
    }
}
