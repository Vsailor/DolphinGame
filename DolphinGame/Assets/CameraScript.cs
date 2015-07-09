using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public GameObject Dolphin;
    public GameObject ScoreDisplay;
    public GameObject TimeDisplay;
    public GameObject QuitButton;
    public GameObject Timer;
    private int MaxTime = 60;
    private float OldOrtographicSize;
    // Use this for initialization
    void Start()
    {
        OldOrtographicSize = Camera.main.orthographicSize;
    }

    void MoveDisplays()
    {
        if (Dolphin.transform.position.y > this.transform.position.y)
        {
            ScoreDisplay.transform.localScale = new Vector3(ScoreDisplay.transform.localScale.x + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
                ScoreDisplay.transform.localScale.y + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
                ScoreDisplay.transform.localScale.z);
            TimeDisplay.transform.localScale = new Vector3(TimeDisplay.transform.localScale.x + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
                TimeDisplay.transform.localScale.y + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
                TimeDisplay.transform.localScale.z);
            QuitButton.transform.localScale = new Vector3(QuitButton.transform.localScale.x + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
    QuitButton.transform.localScale.y + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
    QuitButton.transform.localScale.z);
            Camera.main.orthographicSize += Dolphin.transform.position.y - this.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        else if (Dolphin.transform.position.y < this.transform.position.y && Camera.main.orthographicSize > 8.56)
        {
            ScoreDisplay.transform.localScale = new Vector3(ScoreDisplay.transform.localScale.x - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
     ScoreDisplay.transform.localScale.y - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
     ScoreDisplay.transform.localScale.z);
            TimeDisplay.transform.localScale = new Vector3(TimeDisplay.transform.localScale.x - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
TimeDisplay.transform.localScale.y - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
TimeDisplay.transform.localScale.z);
            QuitButton.transform.localScale = new Vector3(QuitButton.transform.localScale.x - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
QuitButton.transform.localScale.y - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
QuitButton.transform.localScale.z);
            Camera.main.orthographicSize -= this.transform.position.y - Dolphin.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        ScoreDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Camera.main.pixelHeight - 50, 2));
        TimeDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Camera.main.pixelHeight - 50, 2));
        QuitButton.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(100, Camera.main.pixelHeight - 50, 2));
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Dolphin.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
        MoveDisplays();
        if (Timer.GetComponent<TextMesh>().text == "0")
        {
            Application.LoadLevel("EndScreen");
        }
        Timer.GetComponent<TextMesh>().text = (MaxTime - (int)(Time.time)).ToString();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
