using UnityEngine;
using System.Collections;

public class MainButtonScript : MonoBehaviour
{
    void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            var obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(-2500f, obj.transform.position.y, obj.transform.position.z);
            GameObject.Find("StartScreenBackground").GetComponent<StartScreenScript>().IsActive = true;
        }
        if (this.name == "PlayAgainButton")
        {
            GameObject.Find("Dolphin").GetComponent<DolphinScript>().IsActive = true;
            GameObject.Find("Main Camera").GetComponent<CameraScript>().IsActive = true;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
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
