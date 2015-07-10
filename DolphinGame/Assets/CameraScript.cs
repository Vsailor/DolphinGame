using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public int ScoreAmount = 0;
    public GameObject Dolphin;
    public GameObject ScoreDisplay;
    public GameObject TimeDisplay;
    public GameObject QuitButton;
    public GameObject Timer;
    public GameObject Score;
    public GameObject Swoosh;
    private int MaxTime = 60;

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
            Swoosh.transform.localScale = new Vector3(Swoosh.transform.localScale.x + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
Swoosh.transform.localScale.y + (Dolphin.transform.position.y - this.transform.position.y) / 4.3f,
Swoosh.transform.localScale.z);
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
            Swoosh.transform.localScale = new Vector3(Swoosh.transform.localScale.x - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
Swoosh.transform.localScale.y - (this.transform.position.y - Dolphin.transform.position.y) / 4.3f,
Swoosh.transform.localScale.z);
            Camera.main.orthographicSize -= this.transform.position.y - Dolphin.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        ScoreDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 150, Camera.main.pixelHeight - 50, 2));
        TimeDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Camera.main.pixelHeight - 50, 2));
        QuitButton.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(150, Camera.main.pixelHeight - 50, 2));
        Swoosh.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 50, 2));
    }
    bool LargeJump = false;
    void Update()
    {
        this.transform.position = new Vector3(Dolphin.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
        MoveDisplays();

        if (!LargeJump && Camera.main.orthographicSize >= 15)
        {
            ScoreAmount += 30;
            LargeJump = true;
            Swoosh.SetActive(true);
        }
        else
        {
            if (Camera.main.orthographicSize < 15)
            {
                LargeJump = false;
                Swoosh.SetActive(false);
            }
        }
        if (Timer.GetComponent<TextMesh>().text == "0")
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + @"\Score", ScoreAmount.ToString());
            Application.LoadLevel("EndScreen");
        }
        Timer.GetComponent<TextMesh>().text = (MaxTime - (int)(Time.timeSinceLevelLoad)).ToString();
        Score.GetComponent<TextMesh>().text = ScoreAmount.ToString();

    }
}
