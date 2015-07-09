using UnityEngine;
using System.Collections;

public class PlayScreenQuitButtonScript : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("EndScreen");
    }
}
