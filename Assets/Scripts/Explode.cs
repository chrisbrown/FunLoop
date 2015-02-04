using UnityEngine;
using System.Collections;
using System;

public class Explode : MonoBehaviour {
    public float radius = 5.0F;
    public float power = 10.0F;
    private TextManager textMan;
    private PhraseGenerator phraseGen;
    bool isNotExploding = true;
    void Awake()
    {
        textMan = GetComponent<TextManager>();
        phraseGen = GetComponent<PhraseGenerator>();
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        bool eq = string.Equals(phraseGen.phrase, textMan.text, StringComparison.OrdinalIgnoreCase);
        Debug.Log(phraseGen.phrase + " " + textMan.text + " " + eq);
        if (eq && isNotExploding)
        {  
            Vector3 explosionPos = new Vector3(0, 0, 0);
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                hit.enabled = true;
                if (hit && hit.rigidbody)
                {
                    hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    hit.rigidbody.useGravity = true;
                    hit.enabled = false;
                }
            }
            textMan.score++;
            textMan.text = "";
            Invoke("showNewPhrase", 1);
            isNotExploding = false;
        }
	}


    void showNewPhrase()
    {
        phraseGen.showPhrase();
        isNotExploding = true;
    }

    IEnumerator reEnable(Collider c, float time)
    {
        yield return new WaitForSeconds(time);
        c.enabled = true;
    }
}
