using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public GameObject Dolphin;
    public GameObject ScoreDisplay;
    private float OldOrtographicSize;
    // Use this for initialization
    void Start () {
        OldOrtographicSize = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Dolphin.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
        if (Dolphin.transform.position.y > this.transform.position.y)
        {
            ScoreDisplay.transform.localScale = new Vector3(ScoreDisplay.transform.localScale.x + (Dolphin.transform.position.y - this.transform.position.y) / 4.4f,
                ScoreDisplay.transform.localScale.y + (Dolphin.transform.position.y - this.transform.position.y) / 4.4f,
                ScoreDisplay.transform.localScale.z);
            Camera.main.orthographicSize += Dolphin.transform.position.y - this.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        else if (Dolphin.transform.position.y < this.transform.position.y && Camera.main.orthographicSize >8.56)
        {

            ScoreDisplay.transform.localScale = new Vector3(ScoreDisplay.transform.localScale.x - (this.transform.position.y - Dolphin.transform.position.y) / 4.4f,
     ScoreDisplay.transform.localScale.y - (this.transform.position.y - Dolphin.transform.position.y) / 4.4f,
     ScoreDisplay.transform.localScale.z);
            Camera.main.orthographicSize -= this.transform.position.y - Dolphin.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        ScoreDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(100, Camera.main.pixelHeight-40, 2));
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
