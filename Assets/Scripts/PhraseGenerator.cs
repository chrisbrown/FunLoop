using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
public class PhraseGenerator : MonoBehaviour {

    private ArrayList nouns;
    private ArrayList verbs;
    bool phraseActive;
    string phrase;
    GameObject[] phraseModel;
    void Awake()
    {
        nouns = getText("nouns.txt");
        verbs = getText("verbs.txt");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!phraseActive)
        {
            generateNewPhrase();
            renderPhrase();
            phraseActive = true;
        }
	}

    void generateNewPhrase() {
        int rand = Random.Range(0, 1);
        if (rand == 0) {
            phrase = (string)nouns[Random.Range(0, nouns.Count - 1)] + " " + (string)verbs[Random.Range(0, verbs.Count - 1)];
        } else {
            phrase = (string)verbs[Random.Range(0, verbs.Count - 1)] + " " + (string)nouns[Random.Range(0, nouns.Count - 1)];
        }
        phraseModel = new GameObject[phrase.Length];
    }

    void renderPhrase()
    {
        float size = 0;
        for (int i = 0; i < phrase.Length; i++)
        {
            string let = "Prefabs/" + phrase.Substring(i, 1);
            Debug.Log(let);
            if (let == "Prefabs/ ")
            {
                size += 0.02f;
            }
            else
            {
                GameObject letter = (GameObject)Instantiate(Resources.Load(let));
                letter.transform.position = new Vector3(0 + size * 100, 0, 0);
                size += letter.GetComponent<BoxCollider>().size.x + 0.004f;
                phraseModel[i] = letter;
            }
        }
        for (int j = 0; j < phraseModel.Length; j++)
        {
            if (phraseModel[j] != null)
            {
                phraseModel[j].transform.position += new Vector3((size / 2) * -100, 0, 0);
            }
        }
    }
    ArrayList getText(string fileName)
    {
        ArrayList res = new ArrayList();
        try
        {
            string line;
            string path = Application.dataPath + "/Scripts/" + fileName; 
            Debug.Log(path);

            StreamReader reader = new StreamReader(path.Replace("/","\\"));
            using (reader)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    res.Add(line);
                }
                reader.Close();
            }
        }
        catch (IOException)
        {
            string err = "IOException- " + fileName + " probably not found.";
            Debug.Log(err);
            throw new IOException();
        }
        return res;
    }
}
