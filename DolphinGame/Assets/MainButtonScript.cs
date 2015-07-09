using UnityEngine;
using System.Collections;

public class MainButtonScript : MonoBehaviour
{

    void Start()
    {

    }
    void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            Application.LoadLevel("StartScreen");
        }
        if (this.name == "WriteAReviewButton")
        {

        }
        if (this.name == "QuitButton")
        {
            Application.Quit();
        }
    }
    void Update()
    {

    }
}
