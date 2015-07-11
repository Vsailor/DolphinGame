using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public bool IsActive = false;
    public GameObject PlayPanel;
    public int ScoreAmount = 0;
    public GameObject Dolphin;
    public GameObject ScoreDisplay;
    public GameObject TimeDisplay;
    public GameObject QuitButton;
    public GameObject Timer;
    public GameObject Score;
    public GameObject Swoosh;
    public GameObject CoinSound;
    private int MaxTime;
    public void CoinSoundPlay()
    {

        CoinSound.GetComponent<AudioSource>().Play();
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
        if (Screen.width == 512 && Screen.height == 384)
        {
            ScoreDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Camera.main.pixelHeight - 50, 2));
            TimeDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Camera.main.pixelHeight - 50, 2));
            QuitButton.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(100, Camera.main.pixelHeight - 50, 2));
        }
        else
        {
            ScoreDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 150, Camera.main.pixelHeight - 50, 2));
            TimeDisplay.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Camera.main.pixelHeight - 50, 2));
            QuitButton.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(150, Camera.main.pixelHeight - 50, 2));

        }

        Swoosh.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 50, 2));
    }
    bool LargeJump = false;
    bool Activated = false;
    void Update()
    {
        if (IsActive)
        {
            if (!Activated)
            {
                MaxTime = (int)(Time.timeSinceLevelLoad + 120);
                Activated = true;
            }
            PlayPanel.active = true;
            this.transform.position = new Vector3(Dolphin.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
            MoveDisplays();


            if (!LargeJump && Camera.main.orthographicSize >= 15)
            {
                ScoreAmount += 100;
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
                GameObject.Find("Dolphin").GetComponent<DolphinScript>().IsActive = false;
                GameObject.Find("Main Camera").GetComponent<CameraScript>().IsActive = false;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
                IsActive = false;
                GameObject.Find("Main Camera").GetComponent<EndSceneScript>().IsActive = true;
                Camera.main.orthographicSize = 7.6f;
                this.transform.position = new Vector3(5000f, 0f, -10f);
            }
            Timer.GetComponent<TextMesh>().text = (MaxTime - (int)(Time.timeSinceLevelLoad)).ToString();
            Score.GetComponent<TextMesh>().text = ScoreAmount.ToString();
        }
        else
        {
            Timer.GetComponent<TextMesh>().text = "120";
            ScoreDisplay.transform.localScale = new Vector3(2f, 2f, 1f);
            TimeDisplay.transform.localScale = new Vector3(2f, 2f, 1f);
            QuitButton.transform.localScale = new Vector3(2f, 2f, 1f);
            Swoosh.transform.localScale = new Vector3(2f, 2f, 1f);
            GameObject.Find("Dolphin").GetComponent<DolphinScript>().Spead = GameObject.Find("Dolphin").GetComponent<DolphinScript>().MinSpead;
            ScoreAmount = 0;
            PlayPanel.active = false;
            Activated = false;
        }
    }
}
