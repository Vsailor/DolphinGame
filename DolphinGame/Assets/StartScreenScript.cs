using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
    void OnMouseDown()
    {
        Application.LoadLevel("Play");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel("Play");
        }
    }
}
