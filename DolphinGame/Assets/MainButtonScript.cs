using UnityEngine;
using System.Collections;

public class MainButtonScript : MonoBehaviour
{
    void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            if (Application.loadedLevelName == "MainMenu")
            {
                Application.LoadLevel("StartScreen");
            }
            else
            {
                Application.LoadLevel("Play");
            }
        }
        if (this.name == "WriteAReviewButton")
        {

        }
        if (this.name == "QuitButton")
        {
            Application.Quit();
        }
    }
}
