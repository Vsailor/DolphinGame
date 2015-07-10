using UnityEngine;
using System.Collections;

public class EndSceneScript : MonoBehaviour {
    public GameObject YourScore;
    public GameObject HighestScore;
	// Use this for initialization
	void Start () {
        var score = System.IO.File.ReadAllText(Application.persistentDataPath + @"\Score");
        YourScore.GetComponent<TextMesh>().text = "Your score: " + score;
        if (System.IO.File.Exists(Application.persistentDataPath + @"\MaxScore"))
        {
            var maxScore = System.IO.File.ReadAllText(Application.persistentDataPath + @"\MaxScore");
            if (int.Parse(maxScore) < int.Parse(score))
            {
                HighestScore.GetComponent<TextMesh>().text = "Highest score: " + score;
                System.IO.File.WriteAllText(Application.persistentDataPath + @"\MaxScore", score.ToString());
            }
            else
            {
                HighestScore.GetComponent<TextMesh>().text = "Highest score: " + maxScore;
            }
        }
        else
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + @"\MaxScore", score.ToString());
            HighestScore.GetComponent<TextMesh>().text = "Highest score: " + score;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
