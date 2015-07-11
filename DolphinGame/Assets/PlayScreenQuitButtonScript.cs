using UnityEngine;
using System.Collections;

public class PlayScreenQuitButtonScript : MonoBehaviour {
    public GameObject MainCamera;
    void OnMouseDown()
    {
        Application.Quit();
    }
}
