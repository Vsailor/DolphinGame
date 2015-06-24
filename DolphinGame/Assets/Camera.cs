using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public GameObject Dolphin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Dolphin.transform.position.x + 7f, this.transform.position.y, this.transform.position.z);
	}
}
