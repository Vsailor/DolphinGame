using UnityEngine;
using System.Collections;

public class EndSceneScript : MonoBehaviour {
    public GameObject YourScore;
    public GameObject HighestScore;
    public bool IsActive = false;
	// Use this for initialization
	void ReadScores() {
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
    bool Done = false;
	// Update is called once per frame
	void Update () {
        if (IsActive)
        {
            if (!Done)
            {
                Done = true;
                ReadScores();
            }
        }
        else
        {
            Done = false;
        }
	}
}
