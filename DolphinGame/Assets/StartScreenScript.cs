using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
    public bool IsActive = false;
    void OnMouseDown()
    {
        if (IsActive)
        {
            IsActive = false;
            GameObject.Find("Dolphin").GetComponent<DolphinScript>().IsActive = true;
            GameObject.Find("Main Camera").GetComponent<CameraScript>().IsActive = true;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
    }
    void Update()
    {
        if (IsActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject.Find("Dolphin").GetComponent<DolphinScript>().IsActive = true;
                GameObject.Find("Main Camera").GetComponent<CameraScript>().IsActive = true;
                GameObject.Find("Main Camera").GetComponent<MainCameraScript>().IsActive = false;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = false;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            }
        }
    }
}
