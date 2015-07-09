using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
    void OnMouseDown()
    {
        Application.LoadLevel("Play");
    }
}
