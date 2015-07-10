using UnityEngine;
using System.Collections;

public class PlayScreenQuitButtonScript : MonoBehaviour {
    public GameObject MainCamera;
    void OnMouseDown()
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + @"\Score", MainCamera.GetComponent<CameraScript>().ScoreAmount.ToString());
        Application.Quit();
    }
}
